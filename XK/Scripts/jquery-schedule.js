;(function($, window, document, undefined){

	var Schedule = function(ele, data, opt){
		this.$element = ele;
		this.defaults = {
			classNum : 13,
			th : ['时间','周一','周二','周三','周四','周五'],
			firstCol : ['1','2','3','4','5','6','7','8','9','10','11','12','13']
		};
		this.options = $.extend({}, this.defaults, opt);

		this.courses = data;
	}

	Schedule.prototype = {
		create : function(){
			var pattern = new RegExp('([\u4E00-\u9FA5\uf900-\ufa2d])(\\d+)-(\\d+)','g');
			var result;
			var obj = [];
			this.courses.forEach(function(course){
				while((result = pattern.exec(course.sksj))!=null){
					var day;
					if(result[1] == '一'){
						day = 1;
					}else if(result[1] == '二'){
						day = 2;
					}else if(result[1] == '三'){
						day = 3;
					}else if(result[1] == '四'){
						day = 4;
					}else{
						day = 5;
					}
					obj.push({
						courseInfo : course.courseInfo,
						day : day,
						begin : result[2],
						end : result[3]
					});
				}
			});

			var classNum = this.options.classNum;
			var arr = new Array();
			for(var i = 1; i <= classNum; i++){
				arr[i] = new Array();
				for(var j = 1; j <= 5; j++){
					arr[i][j] = { hasClass : false };
				}
			}

			for(var i = 0; i < obj.length; i++){
				arr[obj[i].begin][obj[i].day].courseInfo = obj[i].courseInfo;
				arr[obj[i].begin][obj[i].day].rowNum = Number(obj[i].end) - Number(obj[i].begin) + 1;
				for(var j = Number(obj[i].begin); j <= Number(obj[i].end); j++){
					arr[j][obj[i].day].hasClass = true;
				}
			}


			var firstRow = '';
			for(var i = 0; i < this.options.th.length; i++){
				firstRow += '<th>' + this.options.th[i] + '</th>';
			}
			firstRow = '<tr>' + firstRow + '</tr>';
			this.$element.append(firstRow);

			
			for(var i = 1; i <= classNum; i++){
				var tr = $('<tr></tr>');
				tr.append('<td>' + this.options.firstCol[i-1] + '</td>');
				for(var j = 1; j <= 5; j++){
					if(arr[i][j].hasClass && arr[i][j].courseInfo){
						var courseStr = '';
						for(var k = 0; k < arr[i][j].courseInfo.length; k++){
							courseStr += arr[i][j].courseInfo[k];
							if(k != arr[i][j].courseInfo.length - 1){
								courseStr += '<br>';
							}
						}
						tr.append('<td rowspan="'+arr[i][j].rowNum + '">'+ courseStr + '</td>');
					}else if(!arr[i][j].hasClass){
						tr.append('<td></td>');
					}
				}
				this.$element.append(tr);
			}

			return this.$element;
		}
	};

	$.fn.createSchedule = function(data, options){
		var schedule = new Schedule(this, data, options);

		return schedule.create();
	}
})(jQuery,window,document);