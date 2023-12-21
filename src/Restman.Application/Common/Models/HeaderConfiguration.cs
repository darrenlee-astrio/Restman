﻿namespace Restman.Application.Common.Models;

public class HeaderConfiguration
{
    public bool Enable { get; set; } = false;
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}