(function ($) {
    /* User Management Start */
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
    /* User Management End */

    /* Company Management Start */
    $(".add-new-company").on("click",
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
    /* Company Management End */


    /* Peronal Management Start */
    $(".add-new-personal").on("click",
        function () {
            $("#beupdatedPersonalId").val(0);
            $("#beupdatedPersonalFirstName").val("");
            $("#beupdatedPersonalLastName").val("");
            $("#beupdatedPersonalEmail").val("");
            $("#beupdatedPersonalPhone").val("");
            $("#beupdatedPersonalAdress").val("");
            $(".btn-personal-ekle").text("Ekle");
        });

    $(".updatePersonal").on("click",
        function () {
            var beupdatedPersonalId = $(this).attr("value");
            $.ajax({
                url: '/Personal/GetPersonalById/' + beupdatedPersonalId,
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $("#beupdatedPersonalId").val(data.Id);
                    $("#beupdatedPersonalFirstName").val(data.FirstName);
                    $("#beupdatedPersonalLastName").val(data.LastName);
                    $("#beupdatedPersonalEmail").val(data.Email);
                    $("#beupdatedPersonalPhone").val(data.Phone);
                    $("#beupdatedPersonalAdress").val(data.Adress);
                    $("#personalControlUserId option[value='" + data.UserID + "']").prop('selected', true);
                    $(".btn-personal-ekle").text("Güncelle");
                    $("#addPersonal").modal();
                },
                error: function(err) {
                    console.log(err);
                }
            });
        });


    /* Peronal Management End */



    /* Car Management Start */
    $("#btnAddNewCar").on("click",
        function () {
            $("#btnCarMethod").val("0");
            $("#carControlForm").trigger("reset");
            $(".carAddText").text("Araç Ekle");
        });

    $(".btnCarControlEdit").on("click",
        function () {
            var updatedCarId = $(this).attr("value");
            $("#btnCarMethod").val(updatedCarId);
            $(".carAddText").text("Araç Güncelle");
            $.ajax({
                url: '/Car/GetCarById/' + updatedCarId,
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $("#carControlPlaque").val(data.Plaque);
                    $("#carControlPersonalID option[value='" + data.PersonalID + "']").prop('selected', true);
                    var status = 1;
                    if (data.Status === false) {
                        status = 0;
                    };
                    $("#carControlCarStatus option[value='" + status + "']").prop('selected', true);
                    $("#carControlCarType option[value='" + data.CarTypeID + "']").prop('selected', true);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });


})(jQuery);