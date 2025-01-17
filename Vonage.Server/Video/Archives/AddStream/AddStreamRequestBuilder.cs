﻿using System;
using Vonage.Common.Client;
using Vonage.Common.Client.Builders;
using Vonage.Common.Monads;

namespace Vonage.Server.Video.Archives.AddStream;

internal class AddStreamRequestBuilder : IBuilderForArchiveId, IBuilderForApplicationId, IBuilderForStreamId,
    IBuilderForOptional
{
    private bool hasAudio = true;
    private bool hasVideo = true;
    private Guid applicationId;
    private Guid archiveId;
    private Guid streamId;

    /// <inheritdoc />
    public Result<AddStreamRequest> Create() => Result<AddStreamRequest>
        .FromSuccess(new AddStreamRequest
        {
            ApplicationId = this.applicationId,
            ArchiveId = this.archiveId,
            HasAudio = this.hasAudio,
            HasVideo = this.hasVideo,
            StreamId = this.streamId,
        })
        .Bind(BuilderExtensions.VerifyApplicationId)
        .Bind(BuilderExtensions.VerifyArchiveId)
        .Bind(BuilderExtensions.VerifyStreamId);

    /// <summary>
    ///     Disables the audio on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    public IBuilderForOptional DisableAudio()
    {
        this.hasAudio = false;
        return this;
    }

    /// <summary>
    ///     Disables the video on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    public IBuilderForOptional DisableVideo()
    {
        this.hasVideo = false;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForArchiveId WithApplicationId(Guid value)
    {
        this.applicationId = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForStreamId WithArchiveId(Guid value)
    {
        this.archiveId = value;
        return this;
    }

    /// <inheritdoc />
    public IBuilderForOptional WithStreamId(Guid value)
    {
        this.streamId = value;
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
    IBuilderForArchiveId WithApplicationId(Guid value);
}

/// <summary>
///     Represents a builder for ArchiveId.
/// </summary>
public interface IBuilderForArchiveId
{
    /// <summary>
    ///     Sets the ArchiveId.
    /// </summary>
    /// <param name="value">The ArchiveId.</param>
    /// <returns>The builder.</returns>
    IBuilderForStreamId WithArchiveId(Guid value);
}

/// <summary>
///     Represents a builder for StreamId.
/// </summary>
public interface IBuilderForStreamId
{
    /// <summary>
    ///     Sets the StreamId.
    /// </summary>
    /// <param name="value">The StreamId.</param>
    /// <returns>The builder.</returns>
    IBuilderForOptional WithStreamId(Guid value);
}

/// <summary>
///     Represents a builder for optional values.
/// </summary>
public interface IBuilderForOptional : IVonageRequestBuilder<AddStreamRequest>
{
    /// <summary>
    ///     Disables the audio on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    public IBuilderForOptional DisableAudio();

    /// <summary>
    ///     Disables the video on the request.
    /// </summary>
    /// <returns>The builder.</returns>
    public IBuilderForOptional DisableVideo();
}