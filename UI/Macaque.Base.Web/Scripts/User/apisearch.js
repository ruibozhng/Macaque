function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}
function getData() {
    $.ajax({
        cache: false,
        type: "GET",
        url: "http://localhost/Macaque.Base.WebAPI/api/users",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                + 'value="' + data[i].ID + '" /></td>'
                + '<td>' + data[i].UserID + '</td>'
                + '<td>' + data[i].UserName + '</td>'
                + '<td>' + data[i].Gender + '</td>'
                + '<td>' + data[i].Mobile + '</td>'
                + '<td>' + data[i].Email + '</td>'
                + '<td>' + data[i].Grade + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        },
        error: function (xhr, AJAXOptions, thrownError) {
            alert('Failed to retrieve users.');
        }
    });
}
$(document).ready(function () {
    selectView("summary");
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked')
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                $.ajax({
                    type: "DELETE",
                    url: "http://localhost/Macaque.Base.WebAPI/api/users/" + selectedRadio.attr('value'),
                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    }
                });
                break;
            case "add":
                $('#editID').val("");
                $('#editUserId').val("");
                $('#editUserName').val("");
                $('#editPassword').val("");
                $('#editGender').val("");
                $('#editMobile').val("");
                $('#editEmail').val("");
                $('#editGrade').val("");
                selectView("edit");
                $('#submitAdd').show();
                $('#submitEdit').hide();
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "http://localhost/Macaque.Base.WebAPI/api/users/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editID').val(data.ID);
                        $('#editUserId').val(data.UserID);
                        $('#editUserName').val(data.UserName);
                        $('#editPassword').val(data.Password);
                        $('#editGender').val(data.Gender);
                        $('#editMobile').val(data.Mobile);
                        $('#editEmail').val(data.Email);
                        $('#editGrade').val(data.Grade);
                        selectView("edit");
                        $('#submitAdd').hide();
                        $('#submitEdit').show();
                    }
                });
                break;
            case "submitAdd":
                $.ajax({
                    type: "POST",
                    url: "http://localhost/Macaque.Base.WebAPI/api/users/",
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        getData();
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    url: "http://localhost/Macaque.Base.WebAPI/api/users/" + selectedRadio.attr('value'),
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        getData();
                    }
                });
                break;
        }
    });
});
