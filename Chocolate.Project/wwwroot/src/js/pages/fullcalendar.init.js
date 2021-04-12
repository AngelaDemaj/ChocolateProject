
/*
Template Name: Adminto - Responsive Bootstrap 4 Admin Dashboard
Author: CoderThemes
File: Full-Calendar init js
*/

!function($) {
    "use strict";
    var meetings = [];
    $.ajax({
        type: "GET",
        url: "/api/meetings",
        dataType: "json",
        contentType: "application/json",
        async: false
    }).done(function (data) {
        meetings = data.map(function (item) {
            item.start = new Date(item.start);
            return item;
        });
    });

    var CalendarApp = function() {
        this.$body = $("body")
        this.$modal = $('#event-modal'),
            this.$event = ('#external-events div.external-event'),
            this.$calendar = $('#calendar'),
            this.$saveCategoryBtn = $('.save-category'),
            this.$categoryForm = $('#add-category form'),
            this.$extEvents = $('#external-events'),
            this.$calendarObj = null
    };


    /* on drop */
    CalendarApp.prototype.onDrop = function (eventObj, date) {
        var $this = this;
        // retrieve the dropped element's stored Event Object
        var originalEventObject = eventObj.data('eventObject');
        var $categoryClass = eventObj.attr('data-class');
        // we need to copy it, so that multiple events don't have a reference to the same object
        var copiedEventObject = $.extend({}, originalEventObject);
        // assign it the date that was reported
        copiedEventObject.start = date;
        if ($categoryClass)
            copiedEventObject['className'] = [$categoryClass];
        // render the event on the calendar
        $this.$calendar.fullCalendar('renderEvent', copiedEventObject, true);
        // is the "remove after drop" checkbox checked?
        if ($('#drop-remove').is(':checked')) {
            // if so, remove the element from the "Draggable Events" list
            eventObj.remove();
        }
    },
        /* on click on event */
        CalendarApp.prototype.onEventClick = function (calEvent, jsEvent, view) {
            var $this = this;
        var form = $("#meetingForm");
        form.empty();
        $("#btnCreate").remove();
        form.append("<label class='col-md-2 col-form-label'>Meeting</label>");
        form.append("<div class='col-md-10'><input class='form-control' type=text value='" + calEvent.title + "' /><span class='input-group-append'></span ></div > ");
            $this.$modal.modal({
                backdrop: 'static'
            });
            $this.$modal.find('form').on('submit', function () {
                calEvent.title = form.find("input[type=text]").val();
                $this.$calendarObj.fullCalendar('updateEvent', calEvent);
                $this.$modal.modal('hide');
                return false;
            });
        },
        /* on select */
        CalendarApp.prototype.onSelect = function (start, end, allDay) {
        var $this = this;
        var form = $("#meetingForm");
        form.empty();
            $this.$modal.modal({
                backdrop: 'static'
            });
        form.append("<label class='col-md-2 col-form-label'>Title</label><div class='col-md-10'><input name='Title' id='meetingTitle' class='form-control'></div><div class='form-group'><label class='col-md-2 col-form-label'>Date</label><div class='col-md-10'><input type='datetime-local' id='meetingDate' class='form-control'> </div></div>");
        if ($("#btnCreate").length == 0) {
            $("#closeBtn").after("<a id='btnCreate' class='btn btn-success' style='color:white'>Add</a>")
            $('#btnCreate').click(function () {
                var title = $('#meetingTitle').val();
                var when = $('#meetingDate').val();

                $.ajax({
                    type: "POST",
                    url: "/api/meetings",
                    data: JSON.stringify({ 'title': title, 'when': when }),
                    dataType: "json",
                    contentType: "application/json"
                });

                $('#event-modal').modal('hide');
                location.reload();

            });
        }
            $this.$modal.find('form').on('submit', function () {
                var title = $("#meetingTitle").val();
                var beginning = $("#meetingDate").val();
                var categoryClass = "bg-info"
                if (title !== null && title.length != 0) {
                    $this.$calendarObj.fullCalendar('renderEvent', {
                        title: title,
                        start: beginning,
                        allDay: false,
                        className: categoryClass
                    }, true);
                    $this.$modal.modal('hide');
                }
                else{
                    alert('You have to give a title to your meeting');
                }
                return false;

            });
            $this.$calendarObj.fullCalendar('unselect');
        },
        CalendarApp.prototype.enableDrag = function() {
            //init events
            $(this.$event).each(function () {
                // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                // it doesn't need to have a start or end
                var eventObject = {
                    title: $.trim($(this).text()) // use the element's text as the event title
                };
                // store the Event Object in the DOM element so we can get to it later
                $(this).data('eventObject', eventObject);
                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });
            });
        }
    /* Initializing */
    CalendarApp.prototype.init = function() {
        this.enableDrag();
        /*  Initialize the calendar  */
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();
        var form = '';
        var today = new Date($.now());

        var defaultEvents =  [{
            title: 'Hey!',
            start: new Date($.now() + 158000000),
            className: 'bg-purple'
        },
            {
                title: 'See John Deo',
                start: today,
                end: today,
                className: 'bg-success'
            },
            {
                title: 'Meet John Deo',
                start: new Date($.now() + 168000000),
                className: 'bg-info'
            },
            {
                title: 'Buy a Theme',
                start: new Date($.now() + 338000000),
                className: 'bg-primary'
            }];

        var $this = this;
        $this.$calendarObj = $this.$calendar.fullCalendar({
            slotDuration: '00:15:00', /* If we want to split day time each 15minutes */
            minTime: '08:00:00',
            maxTime: '19:00:00',
            defaultView: 'month',
            handleWindowResize: true,
            height: $(window).height() - 200,
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            events: meetings,
            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar !!!
            eventLimit: true, // allow "more" link when too many events
            selectable: true,
            drop: function(date) { $this.onDrop($(this), date); },
            select: function (start, end, allDay) { $this.onSelect(start, end, allDay); },
            eventClick: function(calEvent, jsEvent, view) { $this.onEventClick(calEvent, jsEvent, view); }

        });

        //on new event
        this.$saveCategoryBtn.on('click', function(){
            var categoryName = $this.$categoryForm.find("input[name='category-name']").val();
            var categoryColor = $this.$categoryForm.find("select[name='category-color']").val();
            if (categoryName !== null && categoryName.length != 0) {
                $this.$extEvents.append('<div class="external-event bg-' + categoryColor + '" data-class="bg-' + categoryColor + '" style="position: relative;"><i class="mdi mdi-checkbox-blank-circle mr-2 vertical-middle"></i>' + categoryName + '</div>')
                $this.enableDrag();
            }

        });
    },

        //init CalendarApp
        $.CalendarApp = new CalendarApp, $.CalendarApp.Constructor = CalendarApp

}(window.jQuery),

//initializing CalendarApp
    function($) {
        "use strict";
        $.CalendarApp.init()
    }(window.jQuery);