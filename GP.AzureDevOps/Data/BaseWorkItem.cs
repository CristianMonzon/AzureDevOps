// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;

namespace GP.AzureDevOps.Data
{
    public class BaseWorkItem
    {
        protected int TitleMaxLength = 25;

        protected String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        protected string FirstLetterCapital(string str)
        {
            return Char.ToUpper(str[0]) + str.Remove(0, 1);
        }
    }
}