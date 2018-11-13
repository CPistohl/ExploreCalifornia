using System;

namespace ExploreCalifornia.Models
{
	public class FormattingService
	{
		public string AsReadableString(DateTime date)
		{
			return date.ToString("d");
		}
	}
}
