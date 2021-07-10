(function ($) {
    $(".updateUser").on("click",
        function () {
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

    $(".updateCompany").on("click",
        function () {
            var updatedCompanyId = $(this).attr("value");
            $.ajax({
                url: '/Company/GetCompanyById/' + updatedCompanyId,
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $("#updatedCompanyId").val(data.Id);
                    $("#updatedCompanyAdress").val(data.Adress);
                    $("#updatedCompanyEmail").val(data.Email);
                    $("#updatedCompanyEnrolmentNo").val(data.EnrolmentNo);
                    $("#updatedCompanyMersisNo").val(data.MersisNo);
                    $("#updatedCompanyName").val(data.Name);
                    $("#updatedCompanyOfficerFullName").val(data.OfficerFullName);
                    $("#updatedCompanyPhone").val(data.Phone);
                    $(".btn-company-ekle").text("Güncelle");
                    $("#addCompany").modal();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });

    $(".btn-new-company").on("click",
        function () {
            $("#updatedCompanyId").val(0);
            $("#updatedCompanyAdress").val("");
            $("#updatedCompanyEmail").val("");
            $("#updatedCompanyEnrolmentNo").val("");
            $("#updatedCompanyMersisNo").val("");
            $("#updatedCompanyName").val("");
            $("#updatedCompanyOfficerFullName").val("");
            $("#updatedCompanyPhone").val("");
            $(".btn-company-ekle").text("Ekle");
        });
})(jQuery);