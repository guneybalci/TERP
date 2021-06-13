(function ($) {
    $(".updateUser").on("click", function () {
        var updatedUserId = $(this).attr("value");
        $.ajax({
            url: '/User/GetPersonalByIdWithUserAndRole/' + updatedUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#updatedPersonalId").val(data.Id);
                $("#updatedRoleId option[value='" + data.RoleId + "']").prop('selected', true);
                $("#updatedUsername").val(data.UserName);
                $("#updatedFirstName").val(data.FirstName);
                $("#updatedLastName").val(data.LastName);
                $("#updatedEmail").val(data.Email);
                $("#updatedPhone").val(data.Phone);
                $("#updatedAdress").val(data.Adress);
                $("#updatePersonalModal").modal();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
})(jQuery);