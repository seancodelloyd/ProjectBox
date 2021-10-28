﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Autoboxd.Pages
{
    public class Index_Tests : AutoboxdWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
