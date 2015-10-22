﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.GtfsNet.Entities;
using Project.GtfsNet.Entities.Maps;
using Project.GtfsNet.Enums;
using Project.GtfsNet.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace Project.GtfsNet.Test.Tests
{
	public class RoutesParserTest : ParserTestBase
	{
		public override string TestFilePath { get; } =  "feeds/subway/routes.txt";

		public EntityParser<Routes, RoutesMap> _parser = new EntityParser<Routes, RoutesMap>();

		public RoutesParserTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FileIsNotEmpty()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<Routes> parsed = _parser.Parse(textReader);
				List<Routes> parsedList = parsed.ToList();

				Assert.NotNull(parsedList);
				Assert.True(parsedList.Any());
				Assert.Equal(12, parsedList.Count);
			}
		}

		[Fact]
		public void CheckDataIsParsedCorrectly()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<Routes> parsed = _parser.Parse(textReader);
				List<Routes> parsedList = parsed.ToList();

				Routes routes = parsedList[0];

				Assert.Null(routes.AgencyId);
				Assert.Null(routes.Description);
				Assert.Null(routes.Url);

				Assert.Equal("00985F", routes.Color);
				Assert.Equal("1", routes.Id);
				Assert.Equal("Babylon", routes.LongName);
				Assert.Equal("", routes.ShortName);
				Assert.Equal("FFFFFF", routes.TextColor);

				Assert.Equal(RouteType.Rail, routes.Type);
			}
		}
	}
}