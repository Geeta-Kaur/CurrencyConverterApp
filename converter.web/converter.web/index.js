
function GetList() {
  var url = 'http://localhost:5000/api/converter/allcurrencies';
  jQuery.ajax({
    dataType: "json",
    url: url,
    async: true,
    context: document.body,
  })
    .done(function (json) {
      var dropdown = $('#curencylist');
      dropdown.html('');
      for (var i = 0; i < json.length; i++) {
        if (json[i].name != 'GBP') {
          dropdown.append('<option value="' + json[i].name + '">' + json[i].name + '</option>');
        }
      }
    })
    .fail(function (xhr, status, errorThrown) {
      alert("Sorry, there was a problem!");
      console.log("Error: " + errorThrown);
      console.log("Status: " + status);
      console.dir(xhr);
    });

}

$(document).ready(function () {
  GetList();
  $('#btnConvertCurrency').on("click", function () {
    ConvertCurrency();
  });
});


function ConvertCurrency() {
  var convertToCurrency = $('#curencylist option:selected').text();
  var valuetoconvert = $('#valueToConvert').val();
  GetConvertedCurrency(convertToCurrency, valuetoconvert);
}

function GetConvertedCurrency(currencyTo, valueTo) {
  var url = 'http://localhost:5000/api/converter/convertcurrency?ConvertTo=' + currencyTo + '&ConvertFrom=GBP&ValueToConvert=' + valueTo;
  jQuery.ajax({
    dataType: "json",
    url: url,
    async: true,
    context: document.body,
  })
    .done(function (json) {
      $('#convertedValue').text(currencyTo + ' ' + json);
    })
    .fail(function (xhr, status, errorThrown) {
      alert("Sorry, there was a problem!");
      console.log("Error: " + errorThrown);
      console.log("Status: " + status);
      console.dir(xhr);
    });

}



$(function () {
  $('#mainForm').validate({
    rules: {
      valueToConvert: {
        required: true,
        minlength: 1
      }
    },
    messages: {
      valueToConvert:
      {
        required: "Please enter value to convert",
        minlength: "Please enter number"
      }
    },
    submitHandler: function (form) {
      form.submit();
    }
  });
});

