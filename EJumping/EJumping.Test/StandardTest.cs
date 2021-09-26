using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EJumping.Test
{
    public class StandardTest
    {
        [Fact]
        public void TestYield()
        {
            var inputList = new List<InputList>
            {
                new InputList
                {
                    Id = 1,
                    Content = "a"
                }, new InputList
                {
                    Id = 2,
                    Content = "b"
                }, new InputList
                {
                    Id = 3,
                    Content = "c"
                },

            };
            var result = GetOutputList(inputList);
            var select = result.Where(x => x.Id <=2);
            var test = select.ToList();

        }
        private IEnumerable<OutputList> GetOutputList(List<InputList> inputLst)
        {
            for (var i = 1; i <= inputLst.Count(); i++)
            {
                yield return new OutputList
                {
                    Id = i,
                    Changed = "changed " + inputLst[i-1].Content
                };
            }
        }
    }
    public class InputList
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
    public class OutputList
    {
        public int Id { get; set; }
        public string Changed { get; set; }
    }
}
