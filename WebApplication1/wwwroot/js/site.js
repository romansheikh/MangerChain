function highlightSalary(id) {    
    $(`#employeeTable${id} td:nth-child(2)`).css("color", "");
    $(`#employeeTable${id} td:nth-child(2)`).css("background-color", "");
    $(`#employeeTable${id} td:nth-child(3)`).css("color", "green");
    $(`#employeeTable${id} td:nth-child(3)`).css("background-color", "#dfdfdf");
}
function highlightName(id) {  
    $(`#employeeTable${id} td:nth-child(3)`).css("color", "");
    $(`#employeeTable${id} td:nth-child(3)`).css("background-color", "");
    $(`#employeeTable${id} td:nth-child(2)`).css("color", "blue");
    $(`#employeeTable${id} td:nth-child(2)`).css("background-color", "#dfdfdf");
}
function redirectToEmployee() {
    var employeeCode = $('#employeeCode').val();

    $.ajax({
        url: `/api/Employee/GetManagerChain/${employeeCode}`,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            getUserBasicInfoes(data);
        },
        error: function (error) {
            console.error(error);
            Swal.fire({
                title: 'Error!',
                text: 'An error occurred.',
                icon: 'error',
                confirmButtonText: 'Cancel'
            });
        }
    });
}
function getUserBasicInfoes(response) {
    console.log(response)
    var tblreassign = $("#employeeTable2 tbody");
    tblreassign.empty();
    if (response && response.length > 0) {
        var options = response.sort((a, b) => a.positionId - b.positionId).map(item => `
            <tr>
                <td>${item.id}</td>
                <td>${item.name}</td>
                <td>${item.salary}</td>
                <td>${item.salaryWithBonus}</td>
                <td>${formatDate(item.joinDate)}</td>
                <td>${item.position}</td>                           
            </tr>`
        ).join('');
        tblreassign.append(options);
    } else {
        Swal.fire({
            title: 'Not Found!',
            text: 'Please provide a valid employee id.',
            icon: 'error',
            confirmButtonText: 'Cancel'
        });
    }
}
function formatDate(date) {
    var monthNames = [
        "01", "02", "03",
        "04", "05", "06", "07",
        "08", "09", "10",
        "11", "12"
    ];
    date = new Date(date);
    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();
    return day + '-' + monthNames[monthIndex] + '-' + year;
}
$(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^\d].+/, ""));
    if ((event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});
