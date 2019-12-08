$.getJSON( "/api/converter/allcurrencies", function( data ) {
  var options = $("#curencylist");
  $.each( data, function(key, val) {
    options.append(new Option(key, val));
  });
});
