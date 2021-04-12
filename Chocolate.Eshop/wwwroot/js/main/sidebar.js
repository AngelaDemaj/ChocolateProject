/**
 * Donald Plugin - Sidebar
 * 
 * @instance multiple
 * 
 * Sidebar active class will be added to body tag : "sidebar class" + "-active"
 */

function Sidebar(name) {
    return this.init(name);
}

(function ($) {
    'use strict';

    // Private Properties
    var is_mobile = window.innerWidth < Donald.desktop_width;

    var onResizeNavigationStyle = function () {
        if (window.innerWidth < Donald.desktop_width && !is_mobile) {
            this.$sidebar.find('.sidebar-content, .filter-clean').removeAttr('style');
            this.$sidebar.find('.sidebar-content').attr('style', '');
            this.$sidebar.siblings('.toolbox').children(':not(:first-child)').removeAttr('style');
        } else if (window.innerWidth >= Donald.desktop_width) {
            if (!this.$sidebar.hasClass('closed') && is_mobile) {
                this.$sidebar.addClass('closed')
                this.$sidebar.find('.sidebar-content').css('display', 'none');
            }
        }
        is_mobile = window.innerWidth < Donald.desktop_width;
    }

    // Public Properties

    Sidebar.prototype.init = function (name) {
        var self = this;

        self.name = name;
        self.$sidebar = $('.' + name);
        self.isNavigation = false;

        // If sidebar exists
        if (self.$sidebar.length) {

            // check if navigation style
            self.isNavigation = self.$sidebar.hasClass('sidebar-fixed') &&
                self.$sidebar.parent().hasClass('toolbox-wrap');

            if (self.isNavigation) {
                onResizeNavigationStyle = onResizeNavigationStyle.bind(this);
                Donald.$window.on('resize', onResizeNavigationStyle);
            }

            Donald.$window.on('resize', function () {
                Donald.$body.removeClass(name + '-active');
            });

            // Register toggle event
            self.$sidebar.find('.sidebar-toggle, .sidebar-toggle-btn')
                .add(name === 'sidebar' ? '.left-sidebar-toggle' : ('.' + name + '-toggle'))
                .on('click', function (e) {
                    self.toggle();
                    $(this).blur();
                    Donald.recalcAll('.sticky-sidebar');
                    e.preventDefault();
                });

            // Register close event
            self.$sidebar.find('.sidebar-overlay, .sidebar-close')
                .on('click', function (e) {
                    Donald.$body.removeClass(name + '-active');
                    e.preventDefault();
                });
        }
        return false;
    }

    Sidebar.prototype.toggle = function () {
        var self = this;

        // if fixed sidebar
        if (window.innerWidth >= Donald.desktop_width && self.$sidebar.hasClass('sidebar-fixed')) {

            // is closed ?
            var isClosed = self.$sidebar.hasClass('closed');

            // if navigation style's sidebar
            if (self.isNavigation) {

                isClosed || self.$sidebar.find('.filter-clean').hide();

                self.$sidebar.siblings('.toolbox').children(':not(:first-child)').fadeToggle('fast');

                self.$sidebar
                    .find('.sidebar-content')
                    .stop()
                    .animate(
                        {
                            'height': 'toggle',
                            'margin-bottom': isClosed ? 'toggle' : -6
                        }, function () {
                            $(this).css('margin-bottom', '');
                            isClosed && self.$sidebar.find('.filter-clean').fadeIn('fast');
                        }
                    );
            }

            // if shop sidebar
            if (self.$sidebar.hasClass('shop-sidebar')) {

                // change columns
                var $wrapper = $('.main-content .product-wrapper');
                if ($wrapper.length) {
                    if ($wrapper.hasClass('product-lists')) {

                        // if list type, toggle 2 cols or 1 col
                        $wrapper.toggleClass('row cols-xl-2', !isClosed);

                    } else {

                        // if grid type
                        var colData = $wrapper.data('toggle-cols'),
                            colsClasses = $wrapper.attr('class').match(/cols-\w*-*\d/g),
                            // get max cols count
                            maxColsCount = colsClasses ?
                                Math.max.apply(null, colsClasses.map(function (cls) {
                                    return cls.match(/\d/)[0];
                                })) :
                                0;

                        if (isClosed) { // when open
                            4 === maxColsCount &&
                                3 == colData &&
                                $wrapper.removeClass('cols-md-4');

                        } else { // when close
                            if (3 === maxColsCount) {
                                $wrapper.addClass('cols-md-4');

                                if (!colData) {
                                    $wrapper.data('toggle-cols', 3);
                                }
                            }
                        }
                    }
                }
            }

            // finally, toggle fixed sidebar
            self.$sidebar.toggleClass('closed');

        } else {

            self.$sidebar.find('.sidebar-overlay .sidebar-close').css('margin-left', - (window.innerWidth - document.body.clientWidth));

            // activate sidebar
            Donald.$body
                .toggleClass(self.name + '-active')
                .removeClass('closed');

            // issue
            if (window.innerWidth >= 1200 && Donald.$body.hasClass('with-flex-container')) {
                $('.owl-carousel').trigger('refresh.owl.carousel');
            }
        }
    }

    Donald.sidebar = function (name) {
        return new Sidebar().init(name);
    }
})(jQuery);

