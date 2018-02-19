using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public class PagedResponseDto<TDataDto> where TDataDto : IDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TDataDto> Data { get; set; }

        public PagedResponseDto() { }
        public PagedResponseDto(int pageSize, int pageNumber, int totalCount, IEnumerable<TDataDto> data)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalCount = totalCount;
            Data = data;
        }
    }
}
