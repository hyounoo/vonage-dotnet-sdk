﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using Vonage.Common;
using Vonage.Meetings.Common;

namespace Vonage.Meetings.GetAvailableRooms;

/// <summary>
/// </summary>
public struct GetAvailableRoomsResponse
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_links")]
    public HalLinks Links { get; set; }

    /// <summary>
    ///     The number of results returned on this page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// List of all accessible rooms
    /// </summary>
    [JsonPropertyName("_embedded")]
    public List<Room> Rooms { get; set; }

    /// <summary>
    ///     The overall number of available rooms.
    /// </summary>
    public int TotalItems { get; set; }
}