﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface ISendable
    {
        public int Length { get; }

        public int BytesSent { get; }
    }
}
