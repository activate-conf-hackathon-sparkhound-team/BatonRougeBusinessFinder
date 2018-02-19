using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public class PagedResponseDto<TDataDto> where TDataDto : IDto
    {
        public IEnumerable<TDataDto> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PagedResponseDto() { }
        public PagedResponseDto(IEnumerable<TDataDto> data, int totalCount, int pageSize, int pageNumber)
        {
            Data = data;
            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
