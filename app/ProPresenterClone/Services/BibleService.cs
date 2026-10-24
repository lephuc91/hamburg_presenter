using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using ProPresenterClone.Models;

namespace ProPresenterClone.Services
{
    public static class BibleService
    {
        public static readonly string[] Translations = new[]
        {
            "KJV — King James Version",
            "WEB — World English Bible",
            "VI — Kinh Thánh Truyền Thống (Vietnamese)",
            "DE — Lutherbibel 1912 (German)"
        };

        private static readonly List<BibleVerseModel> _verses = BuildSeededScriptures();

        public static List<string> GetBooks()
        {
            return _verses.Select(v => v.Book).Distinct().ToList();
        }

        public static List<int> GetChapters(string book)
        {
            return _verses
                .Where(v => v.Book.Equals(book, StringComparison.OrdinalIgnoreCase))
                .Select(v => v.Chapter)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public static List<BibleVerseModel> Lookup(string translationCode, string queryOrBook, int? chapter = null)
        {
            string shortTrans = translationCode.Split(' ')[0].Trim();
            string q = (queryOrBook ?? "").Trim();

            var pool = _verses.Where(v => v.Translation.Equals(shortTrans, StringComparison.OrdinalIgnoreCase)).ToList();
            if (pool.Count == 0)
                pool = _verses.Where(v => v.Translation == "KJV").ToList();

            if (string.IsNullOrWhiteSpace(q))
                return pool.Take(20).ToList();

            // Check reference syntax e.g. "John 3:16" or "Psalm 23" or "Romans 8:28-39"
            foreach (var book in GetBooks())
            {
                if (q.StartsWith(book, StringComparison.OrdinalIgnoreCase))
                {
                    string rest = q.Substring(book.Length).Trim();
                    if (string.IsNullOrEmpty(rest))
                    {
                        return pool.Where(v => v.Book.Equals(book, StringComparison.OrdinalIgnoreCase) &&
                                               (!chapter.HasValue || v.Chapter == chapter.Value)).ToList();
                    }

                    string[] parts = rest.Split(':');
                    if (int.TryParse(parts[0].Trim(), out int ch))
                    {
                        var chMatches = pool.Where(v => v.Book.Equals(book, StringComparison.OrdinalIgnoreCase) && v.Chapter == ch);
                        if (parts.Length > 1)
                        {
                            string vRange = parts[1].Trim();
                            string[] bounds = vRange.Split('-');
                            if (int.TryParse(bounds[0].Trim(), out int vStart))
                            {
                                int vEnd = (bounds.Length > 1 && int.TryParse(bounds[1].Trim(), out int ve)) ? ve : vStart;
                                return chMatches.Where(v => v.Verse >= vStart && v.Verse <= vEnd).ToList();
                            }
                        }
                        return chMatches.ToList();
                    }
                }
            }

            // Otherwise full-text keyword or reference search
            return pool.Where(v =>
                v.Text.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                v.Reference.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static PresentationDocument CreatePresentationFromVerses(string title, List<BibleVerseModel> verses, bool includeReferenceOnSlide = true)
        {
            var doc = new PresentationDocument
            {
                Name = title,
                Category = "Bible Scripture",
                Author = verses.FirstOrDefault()?.Translation ?? "KJV"
            };

            int idx = 1;
            foreach (var v in verses)
            {
                var slide = new SlideItemModel
                {
                    SlideNumber = idx++,
                    Label = $"{v.Book} {v.Chapter}:{v.Verse}",
                    GroupName = $"{v.Book} {v.Chapter}",
                    GroupColor = Color.FromRgb(0xB8, 0x86, 0x0B),
                    Notes = v.Reference
                };

                slide.Elements.Add(new SlideElementModel
                {
                    Kind = SlideElementKind.Text,
                    Name = "Scripture Text",
                    X = 0.08,
                    Y = 0.12,
                    Width = 0.84,
                    Height = includeReferenceOnSlide ? 0.64 : 0.76,
                    FontFamily = "Georgia",
                    FontSize = 50,
                    IsBold = false,
                    IsItalic = false,
                    TextColor = Colors.White,
                    Text = $"“{v.Text}”"
                });

                if (includeReferenceOnSlide)
                {
                    slide.Elements.Add(new SlideElementModel
                    {
                        Kind = SlideElementKind.Text,
                        Name = "Scripture Reference",
                        X = 0.08,
                        Y = 0.78,
                        Width = 0.84,
                        Height = 0.12,
                        FontFamily = "Roboto",
                        FontSize = 32,
                        IsBold = true,
                        TextColor = Color.FromRgb(0xFF, 0xD5, 0x6B),
                        Text = $"— {v.Book} {v.Chapter}:{v.Verse} ({v.Translation})"
                    });
                }

                doc.Slides.Add(slide);
            }

            return doc;
        }

        private static List<BibleVerseModel> BuildSeededScriptures()
        {
            var list = new List<BibleVerseModel>();

            void Add(string trans, string book, int ch, int v, string text)
            {
                list.Add(new BibleVerseModel { Translation = trans, Book = book, Chapter = ch, Verse = v, Text = text });
            }

            // John 3:16-18 (KJV, WEB, VI, DE)
            Add("KJV", "John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
            Add("KJV", "John", 3, 17, "For God sent not his Son into the world to condemn the world; but that the world through him might be saved.");
            Add("KJV", "John", 3, 18, "He that believeth on him is not condemned: but he that believeth not is condemned already, because he hath not believed in the name of the only begotten Son of God.");
            Add("KJV", "John", 1, 1, "In the beginning was the Word, and the Word was with God, and the Word was God.");
            Add("KJV", "John", 1, 14, "And the Word was made flesh, and dwelt among us, (and we beheld his glory, the glory as of the only begotten of the Father,) full of grace and truth.");
            Add("KJV", "John", 14, 6, "Jesus saith unto him, I am the way, the truth, and the life: no man cometh unto the Father, but by me.");

            // Psalm 23:1-6 (KJV)
            Add("KJV", "Psalm", 23, 1, "The LORD is my shepherd; I shall not want.");
            Add("KJV", "Psalm", 23, 2, "He maketh me to lie down in green pastures: he leadeth me beside the still waters.");
            Add("KJV", "Psalm", 23, 3, "He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake.");
            Add("KJV", "Psalm", 23, 4, "Yea, though I walk through the valley of the shadow of death, I will fear no evil: for thou art with me; thy rod and thy staff they comfort me.");
            Add("KJV", "Psalm", 23, 5, "Thou preparest a table before me in the presence of mine enemies: thou anointest my head with oil; my cup runneth over.");
            Add("KJV", "Psalm", 23, 6, "Surely goodness and mercy shall follow me all the days of my life: and I will dwell in the house of the LORD for ever.");

            // Romans 8:28-39 (KJV)
            Add("KJV", "Romans", 8, 28, "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.");
            Add("KJV", "Romans", 8, 31, "What shall we then say to these things? If God be for us, who can be against us?");
            Add("KJV", "Romans", 8, 37, "Nay, in all these things we are more than conquerors through him that loved us.");
            Add("KJV", "Romans", 8, 38, "For I am persuaded, that neither death, nor life, nor angels, nor principalities, nor powers, nor things present, nor things to come,");
            Add("KJV", "Romans", 8, 39, "Nor height, nor depth, nor any other creature, shall be able to separate us from the love of God, which is in Christ Jesus our Lord.");

            // Genesis 1:1-5 (KJV)
            Add("KJV", "Genesis", 1, 1, "In the beginning God created the heaven and the earth.");
            Add("KJV", "Genesis", 1, 2, "And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters.");
            Add("KJV", "Genesis", 1, 3, "And God said, Let there be light: and there was light.");
            Add("KJV", "Genesis", 1, 4, "And God saw the light, that it was good: and God divided the light from the darkness.");
            Add("KJV", "Genesis", 1, 5, "And God called the light Day, and the darkness he called Night. And the evening and the morning were the first day.");

            // Matthew 5:1-10 (KJV)
            Add("KJV", "Matthew", 5, 3, "Blessed are the poor in spirit: for theirs is the kingdom of heaven.");
            Add("KJV", "Matthew", 5, 4, "Blessed are they that mourn: for they shall be comforted.");
            Add("KJV", "Matthew", 5, 5, "Blessed are the meek: for they shall inherit the earth.");
            Add("KJV", "Matthew", 5, 6, "Blessed are they which do hunger and thirst after righteousness: for they shall be filled.");
            Add("KJV", "Matthew", 5, 7, "Blessed are the merciful: for they shall obtain mercy.");
            Add("KJV", "Matthew", 5, 8, "Blessed are the pure in heart: for they shall see God.");
            Add("KJV", "Matthew", 5, 9, "Blessed are the peacemakers: for they shall be called the children of God.");
            Add("KJV", "Matthew", 5, 14, "Ye are the light of the world. A city that is set on an hill cannot be hid.");

            // Philippians 4:4-13 & Isaiah 40:31 & Jeremiah 29:11
            Add("KJV", "Philippians", 4, 4, "Rejoice in the Lord alway: and again I say, Rejoice.");
            Add("KJV", "Philippians", 4, 6, "Be careful for nothing; but in every thing by prayer and supplication with thanksgiving let your requests be made known unto God.");
            Add("KJV", "Philippians", 4, 7, "And the peace of God, which passeth all understanding, shall keep your hearts and minds through Christ Jesus.");
            Add("KJV", "Philippians", 4, 13, "I can do all things through Christ which strengtheneth me.");
            Add("KJV", "Isaiah", 40, 31, "But they that wait upon the LORD shall renew their strength; they shall mount up with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint.");
            Add("KJV", "Jeremiah", 29, 11, "For I know the thoughts that I think toward you, saith the LORD, thoughts of peace, and not of evil, to give you an expected end.");

            // WEB Translation
            Add("WEB", "John", 3, 16, "For God so loved the world, that he gave his one and only Son, that whoever believes in him should not perish, but have eternal life.");
            Add("WEB", "John", 3, 17, "For God didn't send his Son into the world to judge the world, but that the world should be saved through him.");
            Add("WEB", "Psalm", 23, 1, "Yahweh is my shepherd; I shall lack nothing.");
            Add("WEB", "Psalm", 23, 2, "He makes me lie down in green pastures. He leads me beside still waters.");
            Add("WEB", "Psalm", 23, 3, "He restores my soul. He guides me in the paths of righteousness for his name's sake.");
            Add("WEB", "Psalm", 23, 4, "Even though I walk through the valley of the shadow of death, I will fear no evil, for you are with me. Your rod and your staff, they comfort me.");
            Add("WEB", "Romans", 8, 28, "We know that all things work together for good for those who love God, menu to those who are called according to his purpose.");
            Add("WEB", "Philippians", 4, 13, "I can do all things through Christ, who strengthens me.");

            // Vietnamese (VI — Kinh Thánh Truyền Thống)
            Add("VI", "John", 3, 16, "Vì Đức Chúa Trời yêu thương thế gian, đến nỗi đã ban Con một của Ngài, hầu cho hễ ai tin Con ấy không bị hư mất mà được sự sống đời đời.");
            Add("VI", "John", 3, 17, "Vả, Đức Chúa Trời đã sai Con Ngài xuống thế gian, chẳng phải để đoán xét thế gian đâu, nhưng hầu cho thế gian nhờ Con ấy mà được cứu.");
            Add("VI", "John", 14, 6, "Đức Chúa Jêsus đáp rằng: Ta là đường đi, lẽ thật, và sự sống; chẳng bởi Ta thì không ai được đến cùng Cha.");
            Add("VI", "Psalm", 23, 1, "Đức Giê-hô-va là Đấng chăn giữ tôi: Tôi sẽ chẳng thiếu thốn gì.");
            Add("VI", "Psalm", 23, 2, "Ngài khiến tôi an nghỉ nơi đồng cỏ xanh tươi, Dẫn tôi đến mé nước bình tịnh.");
            Add("VI", "Psalm", 23, 3, "Ngài bổ lại linh hồn tôi, Dẫn tôi vào các lối công bình, vì cớ danh Ngài.");
            Add("VI", "Psalm", 23, 4, "Dầu khi tôi đi trong trũng bóng chết, Tôi sẽ chẳng sợ tai họa nào; vì Chúa ở cùng tôi; Cây trượng và cây gậy của Chúa an ủi tôi.");
            Add("VI", "Romans", 8, 28, "Vả, chúng ta biết rằng mọi sự hiệp lại làm ích cho kẻ yêu mến Đức Chúa Trời, tức là cho kẻ được gọi theo ý muốn Ngài đã định.");
            Add("VI", "Philippians", 4, 13, "Tôi làm được mọi sự nhờ Đấng ban thêm sức cho tôi.");
            Add("VI", "Genesis", 1, 1, "Ban đầu Đức Chúa Trời dựng nên trời và đất.");

            // German (DE — Lutherbibel 1912)
            Add("DE", "John", 3, 16, "Also hat Gott die Welt geliebt, daß er seinen eingeborenen Sohn gab, auf daß alle, die an ihn glauben, nicht verloren werden, sondern das ewige Leben haben.");
            Add("DE", "John", 3, 17, "Denn Gott hat seinen Sohn nicht gesandt in die Welt, daß er die Welt richte, sondern daß die Welt durch ihn selig werde.");
            Add("DE", "Psalm", 23, 1, "Der HERR ist mein Hirte, mir wird nichts mangeln.");
            Add("DE", "Psalm", 23, 2, "Er weidet mich auf einer grünen Aue und führet mich zum frischen Wasser.");
            Add("DE", "Psalm", 23, 3, "Er erquicket meine Seele; er führet mich auf rechter Straße um seines Namens willen.");
            Add("DE", "Psalm", 23, 4, "Und ob ich schon wanderte im finstern Tal, fürchte ich kein Unglück; denn du bist bei mir, dein Stecken und Stab trösten mich.");
            Add("DE", "Romans", 8, 28, "Wir wissen aber, daß denen, die Gott lieben, alle Dinge zum Besten dienen, denen, die nach dem Vorsatz berufen sind.");
            Add("DE", "Philippians", 4, 13, "Ich vermag alles durch den, der mich mächtig macht, Christus.");

            return list;
        }
    }
}

