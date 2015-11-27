$(function projectJs() {
    $.getJSON(location.origin + "/api/categoriasApi", null, function (data) {         
        data.forEach(function (value, index) {
           var tabid = value.id;
            $("#tabsheader").append('<li><a href="#tab' + tabid + '" role="tab" data-toggle="tab"> <i class="fa fa-user pr-5"> </i> ' + value.nombre + '</a></li>');
            $("#tabcontent").append('<div class="tab-pane fade in" id="tab' + tabid + '"><div class="row"><div class="col-md-12">'
                + '<br/><div class="panel panel-primary"><div class="panel-heading">Seleccione una submétrica para evaluar</div><div class="panel-body">'
                + '<select class="form-control" id="select' + tabid + '"><option value="0">--Seleccione una Opcion</option></select><br>'
                + '<table id="table'+tabid+'" class="table table-bordered"><thead><tr><th>id</th><th>Nombre</th><th>Descripcion</th><th>Formula</th><th>Evaluar</th></tr></thead></table>'
                + '</div></div></div></div></div>');
            $.getJSON(location.origin + "/api/subcategoriasApi/" + tabid, null, function (datasub) {
                datasub.forEach(function (value, index) {
                    $("#select" + tabid).append('<option value="' + value.id + '">' + value.nombre + '</option>');
                });
            });
            $("#select" + tabid).on("change", function cargartabla() {                             
                datatable.fnClearTable();                                  
                $.getJSON(location.origin + "/api/subcategoriasApi/" + $("#select" + tabid).val(), null, function (datasub) {
                    datasub.forEach(function (value, index) {
                        datatable.fnAddData({
                            "id": value.id,
                            "nombre": value.nombre,
                            "descripcion": value.descripcion,
                            "formula": value.formula,
                            "evaluar": '<a href="' + location.origin + '/evaluaciones/CreateForm?id=' + value.id + '&proyecto=' + proyectoid + '&formula='+value.formula+'" class="modal-link btn btn-info">Evaluar</a>'
                        });
                    });
                });
            });
            var datatable = $("#table"+tabid).dataTable({
                paginate: true,
                columns:
                    [
                        { data: "id", visible: false },
                        { data: "nombre" },
                        { data: "descripcion" },
                        { data: "formula" },
                        { data: "evaluar" },
                    ]
            });
        });
        $('.nav-tabs a:first').tab('show');
     

    });

})