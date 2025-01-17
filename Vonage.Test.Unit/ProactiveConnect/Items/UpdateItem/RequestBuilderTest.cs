using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Vonage.Common.Failures;
using Vonage.Common.Test.Extensions;
using Vonage.ProactiveConnect.Items.UpdateItem;
using Xunit;

namespace Vonage.Test.Unit.ProactiveConnect.Items.UpdateItem
{
    public class RequestBuilderTest
    {
        private readonly Guid listId;
        private readonly Guid itemId;
        private readonly KeyValuePair<string, object> element;

        public RequestBuilderTest()
        {
            var fixture = new Fixture();
            this.listId = fixture.Create<Guid>();
            this.itemId = fixture.Create<Guid>();
            this.element = fixture.Create<KeyValuePair<string, object>>();
        }

        [Fact]
        public void Build_ShouldReturnFailure_GivenDataIsEmpty() =>
            UpdateItemRequest
                .Build()
                .WithListId(this.listId)
                .WithItemId(this.itemId)
                .Create()
                .Should()
                .BeFailure(ResultFailure.FromErrorMessage("Data cannot be empty."));

        [Fact]
        public void Build_ShouldReturnFailure_GivenItemIdIsEmpty() =>
            UpdateItemRequest
                .Build()
                .WithListId(this.listId)
                .WithItemId(Guid.Empty)
                .Create()
                .Should()
                .BeFailure(ResultFailure.FromErrorMessage("ItemId cannot be empty."));

        [Fact]
        public void Build_ShouldReturnFailure_GivenListIdIsEmpty() =>
            UpdateItemRequest
                .Build()
                .WithListId(Guid.Empty)
                .WithItemId(this.itemId)
                .Create()
                .Should()
                .BeFailure(ResultFailure.FromErrorMessage("ListId cannot be empty."));

        [Fact]
        public void Build_ShouldSetData() =>
            UpdateItemRequest
                .Build()
                .WithListId(this.listId)
                .WithItemId(this.itemId)
                .WithCustomData(new KeyValuePair<string, object>("value1", "value"))
                .WithCustomData(new KeyValuePair<string, object>("value2", 0))
                .WithCustomData(new KeyValuePair<string, object>("value3", true))
                .Create()
                .Map(request => request.Data)
                .Should()
                .BeSuccess(data => data.ToList().Should().BeEquivalentTo(new[]
                {
                    new KeyValuePair<string, object>("value1", "value"),
                    new KeyValuePair<string, object>("value2", 0),
                    new KeyValuePair<string, object>("value3", true),
                }));

        [Fact]
        public void Build_ShouldSetItemId() =>
            UpdateItemRequest
                .Build()
                .WithListId(this.listId)
                .WithItemId(this.itemId)
                .WithCustomData(this.element)
                .Create()
                .Map(request => request.ItemId)
                .Should()
                .BeSuccess(this.itemId);

        [Fact]
        public void Build_ShouldSetListId() =>
            UpdateItemRequest
                .Build()
                .WithListId(this.listId)
                .WithItemId(this.itemId)
                .WithCustomData(this.element)
                .Create()
                .Map(request => request.ListId)
                .Should()
                .BeSuccess(this.listId);
    }
}