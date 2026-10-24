using System;

namespace ProPresenter.Rendering.Web;

public record Cookie(string Name, string Value, string Domain, DateTime Expiration);
