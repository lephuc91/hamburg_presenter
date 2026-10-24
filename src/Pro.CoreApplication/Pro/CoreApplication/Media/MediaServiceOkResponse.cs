namespace Pro.CoreApplication.Media;

public record MediaServiceOkResponse<T>(T Data) : IMediaServiceOkResponse, IMediaServiceResponse;
