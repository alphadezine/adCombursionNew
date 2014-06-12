function dtbles() {
    $('#RushDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10,-1], [5, 10, "All"]] });
    $('#RevisionsDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10, -1], [5, 10, "All"]] });
    $('#NewSignUpsDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10, -1], [5, 10, "All"]] });
    $('#NewOrdersDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10, -1], [5, 10, "All"]] });
    $('#RequestInfoDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10, -1], [5, 10, "All"]] });
    $('#PORequiredInfoDataTable').dataTable({ bFilter: false, bInfo: true, "iDisplayLength": 5, "aLengthMenu": [[5, 10, -1], [5, 10, "All"]] });
};