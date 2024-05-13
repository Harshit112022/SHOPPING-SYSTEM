
    $(document).ready(function () {
        var PageNumber = 1;
        var PageSize = 10;
        var CurrentPage = 0;
        var GlobalTotalCount = 0;
        var counter;
        function GetList(CustomerName, ProductId, ProductCategoriesId, FromDate, ToDate, PageNumber, PageSize) {
         var obj = {
               CustomerName: CustomerName,
               ProductId: ProductId,
               ProductCategoriesId: ProductCategoriesId,
               FromDate: FromDate,
               ToDate: ToDate,
               PageNumber: PageNumber,
               PageSize: PageSize
            }
            $.ajax({
             
                url: "/ShopMaster/GetList",
                    //'@Url.Action("GetList", "ShopMaster")',
                method: "POST",
                data: obj,
                dataType: "json",
                success: function (data) {
                    // console.log(data)
                    //data = JSON.parse(data);
                  
                    console.log("HEllo............")
                    RenderList(data.MasterList)
                    renderPagination(data.TotalCount, data.PageNumber);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
        function Insert() {
            $.ajax({
                url: "/ShopMaster/Insert",
                    //'@Url.Action("Insert", "ShopMaster")',
                method: "GET",
                success: function (response) {
                    $('.modal-body').html(response);
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        }
        function Delete(id) {
            Swal.fire({
                title: "Are you sure?",
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, delete it!"
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                    var obj = { id: id };
                    $.ajax({
                        url: "/ShopMaster/Delete",
                            //'@Url.Action("Delete","ShopMaster")',
                        type: 'POST',
                        data: obj,
                        success: function () {
                            console.log('Success..')
                            GetList(null, null, null, null, null, PageNumber, PageSize);
                        },
                        error: function () {
                            console.log(error);
                        }
                    })
                }
            })
        }
        function Edit(id) {
            var obj = {
                SaleOrdersDetailsId: id,
                PageNumber: PageNumber 
            }
            $.ajax({
                url: '/ShopMaster/Edit/ ' + id,
                //'@Url.Action("Edit", "ShopMaster")',
                method: 'GET',             
                data: obj,                
                success: function (response) {                
                    $('.modal').modal();
                    $('.modal-body').html(response);
                    console.log('Edit Working... 2');
                },
                eror: function () {
                    console.log(error);
                }
            })
        }      
        //function RenderList(list) {
        //    var tableBody = $('#tblMasterShop tbody');
        //    tableBody.empty();
        //    $.each(list, function (index, item) {
        //        var row = '<tr align="center" style="border: 1px solid #807d78;">' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.CustomerName + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.DateSaleOrders + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.ProductName + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.ProductCategory + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.Quantity + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.ProductPrice + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + item.TotalAmmount + '</td>' +
        //            '<td scope="col" style="border: 1px solid #807d78;">' + '<button id="EditSaleOrdersDetails" value="' + item.SaleOrdersDetailsId
        //            + '" class="btn ">Edit</button>' + '&nbsp;&nbsp;' + '<button id = "deleteSaleOrder" value="' + item.SaleOrdersDetailsId
        //            + '" class="btn" >Delete</button>' + '</td>'
        //        tableBody.append(row);
        //    }
        //    )
        //}
        function renderPagination(TotalCount, PageNumber) {
            $(".pagination").empty()
            GlobalTotalCount = TotalCount;
            if (PageNumber > 1) {
                $(".pagination").append(`<li class="page-item "  value=${PageNumber - 1} id="pagenumber"><a class="page-link" href="#" tabindex="-1">Previous</a></li>`)
                CurrentPage = $('#pagenumber').val();
            }
            for (var i = 1; i <= TotalCount; i++) {
                if (PageNumber == i) {
                    $(".pagination").append(` <li class="page-item active" value=${i} id="pagenumber" ><a class="page-link" href="#">${i}</a></li>`)
                    CurrentPage = $('#pagenumber').val();
                } else {
                    $(".pagination").append(` <li class="page-item "   value=${i} id="pagenumber"><a class="page-link" href="#">${i}</a></li>`)
                    CurrentPage = $('#pagenumber').val();
                }
            }
            if (TotalCount != PageNumber) {
                $(".pagination").append(`<li class="page-item"   value=${PageNumber + 1} id="pagenumber"><a class="page-link" href="#">Next</a></li>`)
                CurrentPage = $('#pagenumber').val();
            }
        }
        function search() {
            event.preventDefault(); // Prevent default form submission
            CustomerName = $('#CustomerName').val().trim();
            ProductId = $('#ProductId').val();
            ProductCategoriesId = $('#ProductCategoriesId').val();
            FromDate = $('#FromDate').val();
            ToDate = $('#ToDate').val();
            PageSize = $('#PageSize').val();
            PageNumber = 1;
            console.log("Search Funtion PageSize " + PageSize)
            console.log("Search Funtion PageNumber" + PageNumber)
            GetList(CustomerName, ProductId, ProductCategoriesId, FromDate, ToDate, PageNumber, PageSize);
        }
        $('#reset').click(function () {
            CustomerName = $('#CustomerName').val(null)
            ProductId = $('#ProductId').val(null);
            ProductCategoriesId = $('#ProductCategoriesId').val(null);
            FromDate = $('#FromDate').val(null);
            ToDate = $('#ToDate').val(null);
            PageNumber = 1;
            PageSize = $('#PageSize').val();
            GetList(null, null, null, null, null, PageNumber, PageSize);
        })
        $('#PageSize').change(function () {
            PageSize = $(this).val();
            PageNumber = 1;
            CustomerName = $('#CustomerName').val().trim();
            ProductId = $('#ProductId').val();
            ProductCategoriesId = $('#ProductCategoriesId').val();
            FromDate = $('#FromDate').val();
            ToDate = $('#ToDate').val();
           // PageSize = $('#PageSize').val();
            console.log("Search Funtion PageSize " + PageSize)
            console.log("Search Funtion PageNumber" + PageNumber)
            GetList(CustomerName, ProductId, ProductCategoriesId, FromDate, ToDate, 1, PageSize);
        })
        $('#insert').click(Insert);
        $('#searchForm').submit(search);
        $(document).on('click', '#EditSaleOrdersDetails', function () {
            var id = $(this).val();          
            Edit(id);
        })
        $(document).on('click', '#deleteSaleOrder', function () {
            var id = $(this).val();
            Delete(id);
        })
        $(document).on('click', '#pagenumber', function () {
            console.log("Function get clicked..")
            PageNumber = $(this).val();
            CustomerName = $('#CustomerName').val().trim();
            ProductId = $('#ProductId').val();
            ProductCategoriesId = $('#ProductCategoriesId').val();
            FromDate = $('#FromDate').val();
            ToDate = $('#ToDate').val();
            PageSize = $('#PageSize').val();
            console.log("Search Funtion PageSize " + PageSize)
            console.log("Search Funtion PageNumber" + PageNumber)
            GetList(CustomerName, ProductId, ProductCategoriesId, FromDate, ToDate, PageNumber, PageSize);
        })
        
        function editSave() {
            var formData = $('#form').serialize();
            var CustomerName = $('#CustomerName').val().trim();
            var ProductId = $('#ProductId').val();
            var ProductCategoriesId = $('#ProductCategoriesId').val();
            var FromDate = $('#FromDate').val();
            var ToDate = $('#ToDate').val();
                PageSize = $('#PageSize').val();
            console.log("this form data"+ formData)
            debugger;
            $.ajax({
                url: "/ShopMaster/Edit",
                //'@Url.Action("Edit", "ShopMaster")',
                method: "POST",
                data: formData,
                dataType: "json",
                success: function (response) {
                    console.log("Page Number is ==>" + PageNumber)
                    console.log("save btn log");
                    GetList(CustomerName, ProductId, ProductCategoriesId, FromDate, ToDate, PageNumber, PageSize);
                  //  GetList(null, null, null, null, null, PageNumber, PageSize);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
        $(document).on('click', '#saveBtn', function () {
            editSave();
        })
        GetList();
    })
