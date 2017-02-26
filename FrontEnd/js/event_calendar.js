function RenderEvent(calEvent, jsEvent, view) {
    $('#event_heading').html("Event Details");
    $('#tr_id').toggle(true);
    $('#event_id').html(calEvent.id);
    $('#event_start').val(dateFormat(calEvent.start, 'yyyy-mm-dd HH:MM:ss'));
    $('#event_end').val(dateFormat(calEvent.end, 'yyyy-mm-dd HH:MM:ss'));
    $('#event_title').val(calEvent.title);
    $('#tr_delete').toggle(true);
    $('#event_delete').attr('href', '/home/delete?id=' + calEvent.id);
    $('#tr_savenew').toggle(false);
    $('#event_validation').toggle(false);
}

function CreateEvent() {
    $.ajax({
        type: "POST",
        url: '/home/addevent',
        data: JSON.stringify({
            start: $('#event_start').val(),
            end: $('#event_end').val(),
            title: $('#event_title').val()
        }),
        success: function(response) {
            if (response.Item1 == false) {
                $('#event_validation').html(response.Item2.join('<br/>'));
                $('#event_validation').removeAttr('class').addClass('error');
            } else {
                $('#event_title').val('');
                $('#calendar').fullCalendar('refetchEvents');
                $('#event_validation').html('Event created successfully!');
                $('#event_validation').removeAttr('class').addClass('success');
            }
            $('#event_validation').toggle(true);
        },
        erro: function(data) {
            $('#event_validation').html(data);
            $('#event_validation').removeAttr('class').addClass('error');
            $('#event_validation').toggle(true);
        },
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
    });
}

function DeleteEvent() {
    if (confirm('Are you sure you want to delete this event?')) {
        window.location = '/home/delete?id=' + $('#event_id').html();
    }
}