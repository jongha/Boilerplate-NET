(function() {
  var API_MEMBERLIST, API_TIMEZONE, boilerplateApp;

  API_MEMBERLIST = '/api/Members';

  API_TIMEZONE = '/api/TimeZone';

  boilerplateApp = angular.module('boilerplateApp', []);

  boilerplateApp.controller('membersListCtrl', [
    '$scope', '$http', function($scope, $http) {
      $http.get(API_MEMBERLIST).success(function(data, status, headers, config) {
        return $scope.members = data;
      }).error(function(data, status, headers, config) {
        return console.log(data);
      });
    }
  ]);

  boilerplateApp.controller('homeIndexCtrl', [
    '$scope', '$http', function($scope, $http) {
      var getTimeZones;
      $scope.countries = ['Korea', 'Japan', 'United States of America'];
      $scope.countrySelected = {
        name: $scope.countries[0].name
      };
      $scope.selectCountry = function() {
        getTimeZones($scope.country);
      };
      getTimeZones = function(country) {
        return $http.get(API_TIMEZONE + '?country=' + country).success(function(data, status, headers, config) {
          $scope.timeZones = data;
          return $scope.timeZone = data[0].StandardName;
        }).error(function(data, status, headers, config) {
          return console.log(data);
        });
      };
      getTimeZones();
    }
  ]);

  $(document).ready(function() {
    var memberList;
    memberList = $('#memberList');
    if (memberList && memberList.length) {
      $.ajax({
        url: API_MEMBERLIST,
        success: function(data, textStatus, jqXHR) {
          var datum, tr, _i, _len;
          for (_i = 0, _len = data.length; _i < _len; _i++) {
            datum = data[_i];
            tr = $('<tr></tr>');
            tr.append($('<td></td>').html(datum.Id));
            tr.append($('<td></td>').html(datum.Email));
            tr.append($('<td></td>').html(datum.Name));
            tr.append($('<td></td>').html(datum.CreateDate));
            memberList.append(tr);
          }
        },
        dataType: 'json'
      });
    }
  });

}).call(this);

//# sourceMappingURL=script.js.map
