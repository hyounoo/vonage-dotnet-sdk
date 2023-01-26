﻿using System.Net.Http.Headers;
using Vonage.Common.Monads;

namespace Vonage.Common.Client;

/// <summary>
///     Dedicated HttpRequest builder for VonageRequests.
/// </summary>
public class VonageRequestBuilder
{
    private readonly HttpRequestMessage request;
    private Maybe<AuthenticationHeaderValue> authenticationHeader = Maybe<AuthenticationHeaderValue>.None;
    private Maybe<HttpContent> requestContent = Maybe<HttpContent>.None;

    private VonageRequestBuilder(HttpMethod httpMethod, string endpointUri)
    {
        this.request = new HttpRequestMessage(httpMethod, endpointUri);
    }

    public HttpRequestMessage Build()
    {
        this.authenticationHeader.IfSome(header => this.request.Headers.Authorization = header);
        this.requestContent.IfSome(content => this.request.Content = content);
        return this.request;
    }

    public static VonageRequestBuilder Initialize(HttpMethod method, string endpointUri) => new(method, endpointUri);

    public VonageRequestBuilder WithAuthorizationToken(string token)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            this.authenticationHeader = new AuthenticationHeaderValue("Bearer", token);
        }

        return this;
    }

    public VonageRequestBuilder WithContent(HttpContent content)
    {
        if (content != null)
        {
            this.requestContent = content;
        }

        return this;
    }
}