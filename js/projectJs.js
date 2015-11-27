$(function projectJs() {
    $.getJSON(location.origin + "/api/categoriasApi", null, function (data) {

        data.forEach(function (value, index) {
            var tabid = value.id;
            $("#tabsheader").append('<li><a href="#tab' + tabid + '" role="tab" data-toggle="tab"> <i class="fa fa-user pr-5"> </i> ' + value.nombre + '</a></li>');
            $("#tabcontent").append('<div class="tab-pane fade in" id="tab' + tabid +'"><div class="row"><div class="col-md-12">'
                +'<div class="panel panel-default"><div class="panel-heading">Seleccione una submétrica para evaluar</div><div class="panel-body">'
                + '<select class="form-control" id="select' + tabid + '"></select></div></div></div></div></div>');
            $.getJSON(location.origin + "/api/subcategoriasApi/" + tabid, null, function (datasub) {
                datasub.forEach(function (value, index) { 
                    $("#select"+tabid).append('<option value="'+value.id+'">'+value.nombre+'</option>')
                });
            });
        });
    });
})