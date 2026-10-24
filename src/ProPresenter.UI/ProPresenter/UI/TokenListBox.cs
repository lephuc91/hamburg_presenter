using Pro.DO.Token;
using Pro.UI.Controls;

namespace ProPresenter.UI;

public class TokenListBox<TToken> : TokenListBox<TToken, TokenCollection<TToken>> where TToken : TokenBase
{
}
