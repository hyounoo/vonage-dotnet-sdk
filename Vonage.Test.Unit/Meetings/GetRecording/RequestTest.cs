﻿using System;
using AutoFixture;
using FluentAssertions;
using Vonage.Common.Failures;
using Vonage.Common.Test.Extensions;
using Vonage.Meetings.GetRecording;
using Xunit;

namespace Vonage.Test.Unit.Meetings.GetRecording
{
    public class RequestTest
    {
        private readonly Guid recordingId;

        public RequestTest()
        {
            var fixture = new Fixture();
            this.recordingId = fixture.Create<Guid>();
        }

        [Fact]
        public void GetEndpointPath_ShouldReturnApiEndpoint() =>
            GetRecordingRequest.Parse(this.recordingId)
                .Map(request => request.GetEndpointPath())
                .Should()
                .BeSuccess($"/beta/meetings/recordings/{this.recordingId}");

        [Fact]
        public void Parse_ShouldReturnFailure_GivenRoomIdIsNullOrWhitespace() =>
            GetRecordingRequest.Parse(Guid.Empty)
                .Should()
                .BeFailure(ResultFailure.FromErrorMessage("RecordingId cannot be empty."));

        [Fact]
        public void Parse_ShouldReturnSuccess_GivenValuesAreProvided() =>
            GetRecordingRequest.Parse(this.recordingId)
                .Should()
                .BeSuccess(request => request.RecordingId.Should().Be(this.recordingId));
    }
}