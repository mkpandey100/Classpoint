﻿namespace ClassPoint.Application.Common;

public class ResponseOutputDto<T> : OutputDto
{
    public T Data { get; set; }
}