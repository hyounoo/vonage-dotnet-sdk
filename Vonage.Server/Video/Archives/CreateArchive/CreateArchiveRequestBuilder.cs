﻿using System;
using Vonage.Common.Client;
using Vonage.Common.Client.Builders;
using Vonage.Common.Monads;

namespace Vonage.Server.Video.Archives.CreateArchive;

internal class CreateArchiveRequestBuilder : IBuilderForSessionId, IBuilderForApplicationId, IBuilderForOptional
{
    private bool hasAudio = true;
    private bool hasVideo = true;
    private Guid applicationId;
    private Layout layout;
    private Maybe<string> name = Maybe<string>.None;
    private OutputMode outputMode = OutputMode.Composed;
    private RenderResolution resolution = RenderResolution.StandardDefinitionLandscape;
    private StreamMode streamMode = StreamMode.Auto;
    private string sessionId;

    /// <inheritdoc />
    public Result<CreateArchiveRequest> Create() =>
        Result<CreateArchiveRequest>.FromSuccess(new CreateArchiveRequest
            {
                ApplicationId = this.applicationId,
                SessionId = this.sessionId,
                OutputMode = this.outputMode,
                StreamMode = this.streamMode,
                HasAudio = this.hasAudio,
                HasVideo = this.hasVideo,
                Layout = this.layout,
                Name = this.name,
                Resolution = this.resolution,
            })
            .Bind(BuilderExtensions.VerifyApplicationId)
            .Bind(BuilderExtensions.VerifySessionId);

    /// <inheritdoc />
    public IBuilderForOptional DisableAudio()
    {
        this.hasAudio = false;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional DisableVideo()
    {
        this.hasVideo = false;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForSessionId WithApplicationId(Guid value)
    {
        this.applicationId = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithArchiveLayout(Layout value)
    {
        this.layout = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithName(string value)
    {
        this.name = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithOutputMode(OutputMode value)
    {
        this.outputMode = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithRenderResolution(RenderResolution value)
    {
        this.resolution = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithSessionId(string value)
    {
        this.sessionId = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithStreamMode(StreamMode value)
    {
        this.streamMode = value;
        return this;
    }
}

/// <summary>
///     Represents a builder for ApplicationId.
/// </summary>
public interface IBuilderForApplicationId
{
    /// <summary>
    ///     Sets the ApplicationId.
    /// </summary>
    /// <param name="value">The ApplicationId.</param>
    /// <returns>The builder.</returns>
    IBuilderForSessionId WithApplicationId(Guid value);
}

/// <summary>
///     Represents a builder for SessionId.
/// </summary>
public interface IBuilderForSessionId
{
    /// <summary>
    ///     Sets the SessionId.
    /// </summary>
    /// <param name="value">The SessionId.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithSessionId(string value);
}

/// <summary>
///     Represents a builder for optional values.
/// </summary>
public interface IBuilderForOptional : IVonageRequestBuilder<CreateArchiveRequest>
{
    /// <summary>
    ///     Disables the audio on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    IBuilderForOptional DisableAudio();

    /// <summary>
    ///     Disables the video on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    IBuilderForOptional DisableVideo();

    /// <summary>
    ///     Sets the archive's layout.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithArchiveLayout(Layout value);

    /// <summary>
    ///     Sets the name of the archive.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithName(string value);

    /// <summary>
    ///     Sets the output mode.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithOutputMode(OutputMode value);

    /// <summary>
    ///     Sets the resolution.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithRenderResolution(RenderResolution value);

    /// <summary>
    ///     Sets the stream mode.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithStreamMode(StreamMode value);
}