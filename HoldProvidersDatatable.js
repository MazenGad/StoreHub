$(document).ready(function () {
    // التحقق إذا كان DataTable مهيأ مسبقًا ثم تدميره
    if ($.fn.DataTable.isDataTable('#viewDatatable')) {
        $('#viewDatatable').DataTable().destroy();
    }

    $('#viewDatatable').DataTable(
        {
            ajax: {
                url: "HoldProviders/GetClients",
                type: "POST",
                dataSrc: 'data',
            },
            processing: true,
            serverSide: true,
            filter: true,
            "deferRender": true,
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false,
                fixedHeader: true,
                responsive: true,
            }],
            columns: [
                { "data": "id", "name": "Id" },
                { data: "name", name: "Name" ,"autoWidth": true },
                { data: "phone", name: "Phone" ,"autoWidth": true },
                {
                    data: {
                        _: 'subCategory.nameAr',
                    }
                },
                { data: "location", name: "Location", "autoWidth": true },
                {
                    "render": function (data, type, row) { return "<input type='button' data-toggle='modal' data-target='#exampleModalCenter22' value='عرض' class='btn btn - purple btn - rounded' onclick='GetImages(`" + row.id + "`)' />"; }
                },
                {
                    "render": function (data, type, row) { return "<input type='button' data-toggle='modal' data-target='#CommentDelegateModal' value='عرض' class='btn btn - purple btn - rounded' onclick='GetCommentDelegate(`" + row.id + "`)' />"; }
                },
                {
                    "render": function (data, type, row) { return "<input type='button' data-toggle='modal' data-target='#OfferDelegateModal' value='عرض' class='btn btn - purple btn - rounded' onclick='GetOfferDelegate(`" + row.id + "`)' />"; }
                },
                {
                    
                    "render": function (data, type, row, meta) { return "<input type='button' data-toggle='modal' data-target='#UsersModal' value='عرض' class='btn btn - purple btn - rounded' onclick='GetUsers(`" + row.userId + '`,`' + row.id + '`,`'+meta.row+ "`)' />"; }
                },
                { data: "time", name: "Time", "autoWidth": true },
                {
                    data: "img",
                    "render": function (data, type, row) {
                        return '<img src="' + data + '" width="100" height="100" />';
                    }
                },                
                { data: "price", name: "Price", "autoWidth": true },                
                {
                    data: "isActive",
                    "render": function (data, type, row) {

                        if (data == true) {
                            return '<label id="' + row.id + '" style="color:green;font-size: 17px;">مفعل</label>';
                        }
                        else {
                            return '<label id="' + row.id + '" style="color:red;font-size: 17px;">غير مفعل</label>';
                        }


                    }
                },
                {
                    "render": function (data, type, row) {
                        return `<input type="button" value="تغيير الحالة" onclick="Validation('${ row.id }')" class="btn btn-purple btn-rounded" />`;
                    }
                },
                {
                    "render": function (data, type, row) {
                        return `<input type="button" value="حذف" onclick="DeletePlace('${ row.id }')" class="btn btn-purple btn-rounded" />`;
                    }
                },


            ]
        }
    );
});


// GetImages
function GetImages(Id) {
    var html = "";
    $.ajax({
        url: "/HoldProviders/GetProductImages",
        type: "GET",
        data: { delegateId: Id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.key == 1) {
                //$("#exampleModalCenter22").model("show");
                $.each(data.images, function (i, item) {
                    //html += '<a href="' + item.img + '" data-fancybox="gallery">';
                    html += '<img height="100" width="100" style="border-radius:70%; margin: 10px;" src="' + item.img + '">';
                    html += '</a>';
                    html += '<br/>';
                    html += '<br/>';
                })
                $("#addImages").empty();
                $("#addImages").append(html);
            } else {
                html += '<p style="text-align:center;color:blue;font-size:16px">' + data.msg + '</p>';
                $("#addImages").empty();
                $("#addImages").append(html);
            }
        }
    })
}


// GetSizes
function GetCommentDelegate(Id) {
    var html = "";
    $.ajax({
        url: "/HoldProviders/GetCommentDelegate",
        type: "GET",
        data: { delegateId: Id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.key == 1) {
                //SuggestedProvidersTableBody
                $("#SuggestedProvidersP").hide();
                $('#CommentDelegateTable').show();

                $.each(data.sizes, function (i, item) {
                    //html += '<a href="' + item.img + '" data-fancybox="gallery">';
                    html += `
                                        <tr>
                                        <td>${item.comment}</td>
                                        <td>${item.date}</td>
                                        </tr>
                                        `;
                })
                $("#CommentDelegateTableBody").empty();
                $("#CommentDelegateTableBody").append(html);
            } else {
                $("#SuggestedProvidersP").show();
                $('#CommentDelegateTable').hide();
                $("#CommentDelegateTableBody").empty();

                html += '<p style="text-align:center;color:blue;font-size:16px">' + data.msg + '</p>';
                //$("#SuggestedProvidersTableBody").empty();
                $("#SuggestedProvidersP").empty();
                $("#SuggestedProvidersP").append(html);
            }
        }
    })
}


// GetSizes
function GetOfferDelegate(Id) {
    var html = "";
    $.ajax({
        url: "/HoldProviders/GetOfferDelegate",
        type: "GET",
        data: { delegateId: Id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.key == 1) {
                //SuggestedProvidersTableBody
                $("#SuggestedProvidersP").hide();
                $('#OfferDelegateTable').show();

                $.each(data.sizes, function (i, item) {
                    //html += '<a href="' + item.img + '" data-fancybox="gallery">';
                    html += `
                                        <tr>
                                        <td>${item.titleAr}</td>
                                        <td><img height="100" width="100" style="border-radius:70%; margin: 10px;" src="${item.img}" /></td>
                                        <td>${item.period}</td>
                                        <td>${item.delegateName}</td>
                                        </tr>
                                        `;
                })
                $("#OfferDelegateTableBody").empty();
                $("#OfferDelegateTableBody").append(html);
            } else {
                $("#SuggestedProvidersP").show();
                $('#OfferDelegateTable').hide();
                $("#OfferDelegateTableBody").empty();

                html += '<p style="text-align:center;color:blue;font-size:16px">' + data.msg + '</p>';
                //$("#SuggestedProvidersTableBody").empty();
                $("#SuggestedProvidersP").empty();
                $("#SuggestedProvidersP").append(html);
            }
        }
    })
}


function GetUsers(userId, id,meta) {
    var html = "";
    $.ajax({
        url: "/HoldProviders/GetUsers",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.key == 1) {
                html += `
                                
                                    <div class="form-group">
                                        <label asp-for="PlaceId" class="control-label">اسم العميل</label>
                                        <select id="selectedUser" name="users" class="select-2 form-control">
                                            <option value="">لا يوجد</option>                                        
                                        `;
                $.each(data.users, function (i, item) {                    
                    
                    if (item.id == userId) {
                        html += `
                                
                                <option value="${item.id}" selected>${item.name}</option>                                        
                            `;
                    }
                    else {
                        html += `
                                
                                <option value="${item.id}" >${item.name}</option>                                        
                            `;
                    }
                    
                    
                });
                html += `
                            </select>
                                    </div>
                                    <button class="btn" onclick="AddNewUser()">اضافة مستخدم جديد</button>
                                
                        `;
                bt = `
                            <button type="button" class="btn btn-primary" data-dismiss="modal">الغاء</button>
                            <input type="button" value="حفظ" data-dismiss="modal" class="btn-new-style btn-rounded" onclick="SetPlaceUser(${id},${meta})" />
                        `;
                $("#ProvidersUsersContainer").empty();
                $("#ProvidersUsersContainer").append(html);
                $("#submitBt").empty();
                $("#submitBt").append(bt);                 
            } else {                

                html += '<p style="text-align:center;color:blue;font-size:16px">' + data.msg + '</p>';
                $("#ProvidersUsersContainer").empty();
                $("#ProvidersUsersContainer").append(html);
            }
        }
    })
}


function Validation(id) {
    $.ajax({
        url: "/HoldProviders/ChangeState",
        type: "POST",
        dataType: "json",
        data: {
            id: id
        },
        success: function (result) {

            if (result.data == true) {
                $('#' + id).css('color', 'green');
                $('#' + id).html('مفعل');
            } else if (result.data == false) {
                $('#' + id).css('color', 'red');
                $('#' + id).html('غير مفعل');

            }
            location.reload();
        },
        failure: function (info) {

        }
    });
}

function SetPlaceUser(id,meta) {
    var e = document.getElementById("selectedUser");
    var userId = e.value;
    $.ajax({
        url: "/HoldProviders/SetPlaceUser",
        type: "POST",
        dataType: "json",
        data: {
            userId: userId,
            id: id,
        },
        success: function (result) {
            Swal.fire({
                title: 'تم بنجاح',
                icon: 'success',
                timer: 1500
            });
            var table = $('#viewDatatable').DataTable();
            var d = table.row(meta).data();
            d.id = userId;
            table.row(meta).data(d).draw();      
        },
        failure: function (info) { 
            Swal.fire({
                icon: 'error',
                title: 'خطأ بالعملية...',
                timer: 1500,
            });
        }
    });
}

function isSpecial(id) {
    $.ajax({
        url: "/HoldProviders/IsSpecial",
        type: "POST",
        dataType: "json",
        data: {
            id: id
        },
        success: function (result) {
            if (result.data == true) {               
                SetSpecialPrice(id);
            } else if (result.data == false) {
                html = `
                            <input type="hidden" id="placeId" name="placeId" value="${id}">
                            <input id="SpecialPrice" value="1" class="form-control" type="number" min="1" step="any" />
                        `;
                $("#inputPrice").empty();
                $("#SpecialBtn").empty();
                $("#inputPrice").append(html);
                $("#SpecialBtn").append(`<button type="button" data-dismiss="modal" class="btn btn-primary" onclick="SetSpecialPrice(${id})">حفظ</button>`);
                $('#SpecialModal').modal('show');

            }
            location.reload();
        },
        failure: function (info) {

        }
    });
}

function SetSpecialPrice(id) {
    price = document.getElementById('SpecialPrice')?.value;
    $("#inputPrice").empty();
    $.ajax({
        url: "/HoldProviders/SpecialPrice",
        type: "POST",
        dataType: "json",
        data: {
            id: id,
            price: price,
        },
        success: function (result) {
            Swal.fire({
                title: 'تم بنجاح',
                icon: 'success',
                timer: 1500
            }).then(() => {
                if (result.data == true) {
                    $('#s' + id).css('color', 'green');
                    $('#s' + id).html('مميز');
                } else if (result.data == false) {
                    $('#s' + id).css('color', 'red');
                    $('#s' + id).html('غير مميز');

                }
                window.location.reload();
            });

        },
        failure: function (info) {
            Swal.fire({
                icon: 'error',
                title: 'خطأ بالعملية...',
                timer: 1500,
            });
        }
    });
}

function DeletePlace(id) {
    $.ajax({
        url: "/Providers/DeletePlace",
        type: "POST",
        dataType: "json",
        data: {
            id: id
        },
        success: function (result) {
            location.reload();
        },
        failure: function (info) {

        }
    });
}

function AddNewUser() {
    if (!$('#AddNewUser').html()) {
        var html = `
            <div id="AddNewUser">
                <form id="AddNewUserForm" enctype="multipart/form-data" >                    
                     <div class="form-group">
                        <label for="userName" class="control-label">اسم المستخدم</label>
                        <input id="userName" name="userName" class="form-control" />
                    </div>                    
                     <div class="form-group">
                        <label for="phone" class="control-label">الهاتف</label>
                        <input id="phone" name="phone" class="form-control" />
                    </div>
                     <div class="form-group">
                        <label for="password" class="control-label">الرقم السري</label>
                        <input type="password" id="password" name="password" class="form-control" />
                    </div>
                    <div>
                        <a id="AddNewUserBtn" onclick="SubmitNewUser()" class="btn-new-style btn-rounded">اضافة</a>
                    </div>

                </form>
            </div>
            `;
        $("#ProvidersUsersContainer").append(html);
    }
    else {
        $('#AddNewUser').remove();
    }
   
}

function SubmitNewUser() {
    $('#AddNewUserBtn').prop('disabled', true);
    $.ajax({
        type: "POST",
        data: $("#AddNewUserForm").serialize(),
        url: "/HoldProviders/SubmitUser",
        success: function (res) {
            confirm("تم الاضافة بنجاح");
            AddNewUser();
            let html = '<option value="' + res.data.id+'">'+res.data.userName+'</option>';
            $('#selectedUser').append(html);
        },
        error: function (err) {
            confirm(err.responseJSON.msg);
            $('#AddNewUserBtn').prop('disabled', false);
        }
    });
}