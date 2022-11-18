﻿using System;

namespace LetsRun
{
    public class Run
    {
        public bool Ran { get; set; }
        public decimal Distance { get; set; }
        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            return "Ran: " +
                this.Ran +
                "\nDistance " +
                this.Distance +
                "\nDuration: " +
                this.Duration;
        }
    }
}