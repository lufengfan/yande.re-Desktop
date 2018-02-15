using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public enum StatusCode
    {
        /// <summary>
        /// 等效于 HTTP 状态 100。指示客户端可以继续其请求。
        /// </summary>
        Continue = 100,
        /// <summary>
        /// 等效于 HTTP 状态为 101。指示正在更改的协议版本或协议。
        /// </summary>
        SwitchingProtocols = 101,
        /// <summary>
        /// 等效于 HTTP 状态 200。指示请求成功，且请求的信息包含在响应中。 这是要接收的最常见状态代码。
        /// </summary>
        OK = 200,
        /// <summary>
        /// 等效于 HTTP 状态 201。指示请求导致已发送响应之前创建一个新的资源。
        /// </summary>
        Created = 201,
        /// <summary>
        /// 等效于 HTTP 状态 202。指示请求已被接受进行进一步处理。
        /// </summary>
        Accepted = 202,
        /// <summary>
        /// 等效于 HTTP 状态 203。 System.Net.HttpStatusCode.NonAuthoritativeInformation 指示返回的元信息来自而不是原始服务器的缓存副本，因此可能不正确。
        /// </summary>
        NonAuthoritativeInformation = 203,
        /// <summary>
        /// 等效于 HTTP 状态 204。指示已成功处理请求和响应是有意留为空白。
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// 等效于 HTTP 状态 205。指示客户端应重置 （而不是重新加载） 的当前资源。
        /// </summary>
        ResetContent = 205,
        /// <summary>
        /// 等效于 HTTP 206 状态。指示根据包括字节范围的 GET 请求的请求的响应是部分响应。
        /// </summary>
        PartialContent = 206,
        /// <summary>
        /// 等效于 HTTP 状态 300。指示所需的信息有多种表示形式。 默认操作是将此状态视为一个重定向，并按照与此响应关联的位置标头的内容。
        /// </summary>
        MultipleChoices = 300,
        /// <summary>
        /// 等效于 HTTP 状态 300。指示所需的信息有多种表示形式。 默认操作是将此状态视为一个重定向，并按照与此响应关联的位置标头的内容。
        /// </summary>
        Ambiguous = 300,
        /// <summary>
        /// 等效于 HTTP 状态 301。指示已将所需的信息移动到的位置标头中指定的 URI 。当收到此状态时的默认操作是遵循与响应关联的位置标头。
        /// </summary>
        MovedPermanently = 301,
        /// <summary>
        /// 等效于 HTTP 状态 301。指示已将所需的信息移动到的位置标头中指定的 URI。当收到此状态时的默认操作是遵循与响应关联的位置标头。当原始请求方法是 POST 时，重定向的请求将使用 GET 方法。
        /// </summary>
        Moved = 301,
        /// <summary>
        /// 等效于 HTTP 状态 302。指示所需的信息位于的位置标头中指定的 URI。 当收到此状态时的默认操作是遵循与响应关联的位置标头。当原始请求方法是 POST 时，重定向的请求将使用 GET 方法。
        /// </summary>
        Found = 302,
        /// <summary>
        /// 等效于 HTTP 状态 302。指示所需的信息位于的位置标头中指定的 URI。 当收到此状态时的默认操作是遵循与响应关联的位置标头。当原始请求方法是 POST 时，重定向的请求将使用 GET 方法。
        /// </summary>
        Redirect = 302,
        /// <summary>
        /// 等效于 HTTP 状态 303。自动将客户端重定向到的位置标头中指定作为公告的结果的 URI 。对指定的位置标头的资源的请求将会执行与 GET。
        /// </summary>
        SeeOther = 303,
        /// <summary>
        /// 等效于 HTTP 状态 303。自动将客户端重定向到的位置标头中指定作为公告的结果的 URI 。对指定的位置标头的资源的请求将会执行与 GET。
        /// </summary>
        RedirectMethod = 303,
        /// <summary>
        /// 等效于 HTTP 状态 304。指示客户端的缓存的副本是最新。 不会传输资源的内容。
        /// </summary>
        NotModified = 304,
        /// <summary>
        /// 等效于 HTTP 状态 305。指示该请求应使用的位置标头中指定的 uri 的代理服务器。
        /// </summary>
        UseProxy = 305,
        /// <summary>
        /// 等效于 HTTP 状态 306。是对未完全指定的 HTTP/1.1 规范建议的扩展。
        /// </summary>
        Unused = 306,
        /// <summary>
        /// 等效于 HTTP 状态 307。指示请求信息位于的位置标头中指定的 URI 。当收到此状态时的默认操作是遵循与响应关联的位置标头。当原始请求方法是 POST 时，重定向的请求还将使用 POST 方法。
        /// </summary>
        TemporaryRedirect = 307,
        /// <summary>
        /// 等效于 HTTP 状态 307。指示请求信息位于的位置标头中指定的 URI 。当收到此状态时的默认操作是遵循与响应关联的位置标头。当原始请求方法是 POST 时，重定向的请求还将使用 POST 方法。
        /// </summary>
        RedirectKeepVerb = 307,
        /// <summary>
        /// 等效于 HTTP 状态 400。指示无法由服务器理解此请求。如果没有其他错误适用，或者如果具体的错误是未知的或不具有其自己的错误代码发送。
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// 等效于 HTTP 状态 401。指示所请求的资源需要身份验证。www-authenticate 标头包含如何执行身份验证的详细信息。
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// 等效于 HTTP 状态 402。已保留供将来使用。
        /// </summary>
        PaymentRequired = 402,
        /// <summary>
        /// 等效于 HTTP 状态 403。指示服务器拒绝无法完成请求。
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// 等效于 HTTP 状态 404。指示所请求的资源不存在的服务器上。
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// 等效于 HTTP 状态 405。指示请求方法 （ POST 或 GET ）不允许对所请求的资源。
        /// </summary>
        MethodNotAllowed = 405,
        /// <summary>
        /// 等效于 HTTP 状态 406。表示客户端已指定使用 Accept 标头，它将不接受任何可用的资源表示。
        /// </summary>
        NotAcceptable = 406,
        /// <summary>
        /// 等效于 HTTP 状态 407。指示请求的代理要求身份验证。代理服务器进行身份验证标头包含如何执行身份验证的详细信息。
        /// </summary>
        ProxyAuthenticationRequired = 407,
        /// <summary>
        /// 等效于 HTTP 状态 408。指示客户端的服务器预期请求的时间内没有未发送请求。
        /// </summary>
        RequestTimeout = 408,
        /// <summary>
        /// 等效于 HTTP 状态 409。指示该请求可能不会执行由于在服务器上发生冲突。
        /// </summary>
        Conflict = 409,
        /// <summary>
        /// 等效于 HTTP 状态 410。指示所请求的资源不再可用。
        /// </summary>
        Gone = 410,
        /// <summary>
        /// 等效于 HTTP 状态 411。指示缺少必需的内容长度标头。
        /// </summary>
        LengthRequired = 411,
        /// <summary>
        /// 等效于 HTTP 状态 412。表示失败，此请求的设置的条件，无法执行请求。使用条件请求标头，如果匹配项，如设置条件无-If-match，或如果-修改-自从。
        /// </summary>
        PreconditionFailed = 412,
        /// <summary>
        /// 等效于 HTTP 状态 413。指示请求来说太大的服务器能够处理。
        /// </summary>
        RequestEntityTooLarge = 413,
        /// <summary>
        /// 等效于 HTTP 状态 414。指示 URI 太长。
        /// </summary>
        RequestUriTooLong = 414,
        /// <summary>
        /// 等效于 HTTP 状态 415。指示该请求是不受支持的类型。
        /// </summary>
        UnsupportedMediaType = 415,
        /// <summary>
        /// 等效于 HTTP 416 状态。指示从资源请求的数据范围不能返回，或者因为范围的开始处，然后该资源的开头或范围的末尾后在资源的结尾。
        /// </summary>
        RequestedRangeNotSatisfiable = 416,
        /// <summary>
        /// 等效于 HTTP 状态 417。指示无法由服务器满足 Expect 标头中给定。
        /// </summary>
        ExpectationFailed = 417,
        /// <summary>
        /// 等效于 HTTP 状态 420 （自定义）。指示无法保存该条记录。
        /// </summary>
        InvalidRecord = 420,
        /// <summary>
        /// 等效于 HTTP 状态 421 （自定义）。指示用户被节流，请再次尝试。
        /// </summary>
        UserThrottled = 421,
        /// <summary>
        /// 等效于 HTTP 状态 422 （自定义）。指示该资源已被锁定，无法修改。
        /// </summary>
        Locked = 422,
        /// <summary>
        /// 等效于 HTTP 状态 423 （自定义）。指示该资源已经存在。
        /// </summary>
        AlreadyExists = 423,
        /// <summary>
        /// 等效于 HTTP 状态 424 （自定义）。指示给定的参数是非法的。
        /// </summary>
        InvalidParameters = 424,
        /// <summary>
        /// 等效于 HTTP 状态 426。指示客户端应切换到不同的协议，例如 TLS/1.0。
        /// </summary>
        UpgradeRequired = 426,
        /// <summary>
        /// 等效于 HTTP 状态 500。表示在服务器上发生一般性错误。
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// 等效于 HTTP 状态 501。指示服务器不支持所请求的功能。
        /// </summary>
        NotImplemented = 501,
        /// <summary>
        /// 等效于 HTTP 状态 502。指示中间代理服务器从另一个代理或原始服务器接收到错误响应。
        /// </summary>
        BadGateway = 502,
        /// <summary>
        /// 等效于 HTTP 状态 503。指示将服务器暂时不可用，通常是由于高负载或维护。
        /// </summary>
        ServiceUnavailable = 503,
        /// <summary>
        /// 等效于 HTTP 状态 504。指示中间代理服务器在等待来自另一个代理或原始服务器的响应时已超时。
        /// </summary>
        GatewayTimeout = 504,
        /// <summary>
        /// 等效于 HTTP 状态 505。指示服务器不支持请求的 HTTP 版本。
        /// </summary>
        HttpVersionNotSupported = 505
    }
}
