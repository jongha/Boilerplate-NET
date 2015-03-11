(function() {
  var API_MEMBERLIST, API_TIMEZONE, boilerplateApp;

  API_MEMBERLIST = '/api/Members';

  API_TIMEZONE = '/api/TimeZone';

  boilerplateApp = angular.module('boilerplateApp', []);

  boilerplateApp.filter('format', function() {
    return function(input, args) {
      var exp, i, _i, _ref;
      input = input || '';
      for (i = _i = 0, _ref = args.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
        exp = new RegExp('\\{' + i + '\\}', 'gi');
        input = input.replace(exp, args[i]);
      }
      return input;
    };
  });

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
      var getLocalTime;
      getLocalTime = function(utcOffset) {
        var matches, now, tick, utc;
        now = new Date();
        tick = 0;
        if (matches = utcOffset.match(/([+-]?\d{2,2}):(\d{2,2}):(\d{2,2})$/)) {
          tick = ((parseInt(matches[1]) * 60 * 60) + (parseInt(matches[2]) * 60) + parseInt(matches[3])) * 1000;
        }
        utc = now.getTime() + (now.getTimezoneOffset() * 60 * 1000);
        return new Date(utc + tick);
      };
      $scope.selectLanguage = function() {
        location.href = './?lang=' + $scope.language + '&tz=' + $scope.timeZone.Id;
      };
      $scope.selectTimeZone = function() {
        var currentDate, hour, minute;
        currentDate = getLocalTime($scope.timeZone.BaseUtcOffset);
        hour = currentDate.getHours();
        minute = currentDate.getMinutes();
        $scope.hour = hour < 10 ? '0' + hour : hour;
        $scope.minute = minute < 10 ? '0' + minute : minute;
      };
      $http.get(API_TIMEZONE).success(function(data, status, headers, config) {
        var i, _i, _ref;
        $scope.timeZones = data;
        if (!!!$scope.timeZoneParam) {
          $scope.timeZone = data[0];
        } else {
          for (i = _i = 0, _ref = data.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
            if ($scope.timeZoneParam === data[i].Id) {
              $scope.timeZone = data[i];
              break;
            }
          }
        }
        $scope.selectTimeZone();
      }).error(function(data, status, headers, config) {
        return console.log(data);
      });
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
