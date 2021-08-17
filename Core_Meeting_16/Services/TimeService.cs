using System;

namespace Core_Meeting_16.Services
{
    public class TimeService
    {
        public string Time => DateTime.Now.ToLongTimeString();
    }
}