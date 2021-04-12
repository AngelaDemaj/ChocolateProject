

 /*
Template Name: Adminto - Responsive Bootstrap 4 Admin Dashboard
Author: CoderThemes
File: Kanban init js
*/

! function($) {
	"use strict";

	var KanbanBoard = function() {
		this.$body = $("body")
	};

	$("#upcoming, #inprogress, #completed").sortable({
		connectWith: ".taskList",
		placeholder: 'task-placeholder',
		forcePlaceholderSize: true,
		update: function (event, ui) {

			var todo = $("#todo").sortable("toArray");
			var inprogress = $("#inprogress").sortable("toArray");
			var completed = $("#completed").sortable("toArray");
		}
	}).disableSelection();

	//initializing various charts and components
	KanbanBoard.prototype.init = function() {
		
	},

	//init KanbanBoard
	$.KanbanBoard = new KanbanBoard, $.KanbanBoard.Constructor =
	KanbanBoard

}(window.jQuery),

//initializing KanbanBoard
function($) {
	"use strict";
	$.KanbanBoard.init()
}(window.jQuery);
