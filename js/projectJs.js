$(function projectJs() {
	$.getJSON(location.origin + "/api/categoriasApi", null, function (data) {

		for (var x in data) {
			$('#category').append('<option value="' + data['id'] + '">' + data.id_padre + '</option>');
		}

	});
})