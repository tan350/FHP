//Single search
$("#searchButton").click(function () {
    var searchText = $("#searchInput").val().toLowerCase();
    $("table tbody tr").each(function () {
        var found = false;
        $(this).find("td").each(function () {
            if ($(this).text().toLowerCase().indexOf(searchText) !== -1) {
                found = true;
                return false;
            }
        });
        if (found) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
});

$("#clearFilter").click(function (e) {
    e.preventDefault();
    $("#searchInput").val("");
    $("table tbody tr").show();
});

//ColumnWise search
function filterByColumn(columnId) {
    console.log("Filtering records by column: " + columnId);
    var searchValue = document.getElementById(columnId).value.toLowerCase();
    var records = document.querySelectorAll('#recordsTable tbody tr#rowData');

    records.forEach(function (record) {
        var columnText = record.querySelector('.' + columnId).innerText.trim().toLowerCase();

        if (columnText.includes(searchValue)) {
            record.style.display = '';
        } else {
            record.style.display = 'none';
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('searchSrNo').addEventListener('input', function () { filterByColumn('searchSrNo'); });
    document.getElementById('searchPrefix').addEventListener('input', function () { filterByColumn('searchPrefix'); });
    document.getElementById('searchFirstName').addEventListener('input', function () { filterByColumn('searchFirstName'); });
    document.getElementById('searchMiddleName').addEventListener('input', function () { filterByColumn('searchMiddleName'); });
    document.getElementById('searchLastName').addEventListener('input', function () { filterByColumn('searchLastName'); });
    document.getElementById('searchDOB').addEventListener('input', function () { filterByColumn('searchDOB'); });
    document.getElementById('searchDOJ').addEventListener('input', function () { filterByColumn('searchDOJ'); });
    document.getElementById('searchQualification').addEventListener('input', function () { filterByColumn('searchQualification'); });
    document.getElementById('searchCurrentAddress').addEventListener('input', function () { filterByColumn('searchCurrentAddress'); });
    document.getElementById('searchCurrentCompany').addEventListener('input', function () { filterByColumn('searchCurrentCompany'); });
});

