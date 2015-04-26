function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}
function getData() {
    $.ajax({
        type: "GET",
        url: "/Macaque.Base.WebAPI/api/users",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                + 'value="' + data[i].ID + '" /></td>'
                + '<td>' + data[i].UserID + '</td>'
                + '<td>' + data[i].UserName + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
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
                    url: "/api/users/" + selectedRadio.attr('value'),
                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    }
                });
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "/api/users/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editID').val(data.ID);
                        $('#editUserName').val(data.UserName);
                        $('#editPassword').val(data.Password);
                        selectView("edit");
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    url: "/api/users/" + selectedRadio.attr('value'),
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editUserName').val();
                            cells[2].innerText = $('#editPassword').val();
                            selectView("summary");
                        }
                    }
                });
                break;
        }
    });
});