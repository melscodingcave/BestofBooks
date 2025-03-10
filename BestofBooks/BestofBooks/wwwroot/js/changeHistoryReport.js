// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Dropdown functionality for datepickers */
function dropdownStateCHI() {
    document.getElementById("dateRangeDropdown").classList.toggle("show");
}

function returnStateCHI() {
    document.getElementById("dateRangeDropdown").classList.toggle("show");
}

function printMe() {
    PrintPage("printArea");
}

function validateDates(e) {
    var startDate = $("#beginDate").val();
    var endDate = $("#endDate").val();
    if (startDate == "" || endDate == "") {
        alert('Date range is required.');
        e.preventDefault();
    }
}
