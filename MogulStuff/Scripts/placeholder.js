$.widget("ui.placeholder", {
    // default options
    options: {}
    , _create: function () {
        var placeholderText = this.element.attr('placeholder');
        var placeholder = $('<span class="html5ify-placeholder"><label>' + placeholderText + '</label></span>');
        var offs = this.element.offset()
        var width = this.element.width()
        this.element.before(placeholder);
        placeholder.css({
            position: 'absolute',
            top: (offs.top + 2) + "px",
            left: (offs.left + 3) + "px"
        });
        var that = this;
        this.element.bind('focus', function () {
            placeholder.hide();
        });
        this.element.bind('blur', function () {
            if (this.value.length === 0)
                placeholder.show();
        });
    }
    , setText: function (text) {
        $(this.element).prev().find('label').text(text);
    }
    , destroy: function () {
        $.Widget.prototype.destroy.apply(this, arguments); // default destroy
        // now do other stuff particular to this widget
        var span = this.element.prev();
        if (span.hasClass('html5ify-placeholder')) {
            span.remove();
        }
    }
});

$(function () {
    if (!Modernizr.input.placeholder) {
        $('[placeholder]').each(function () {
            $(this).placeholder();
        });
    }
})