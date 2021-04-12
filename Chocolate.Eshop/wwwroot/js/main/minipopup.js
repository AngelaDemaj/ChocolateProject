/**
 * Donald Plugin - MiniPopup
 * 
 * @instance single
 */

(function ($) {
    'use strict';

    // Private Properties

    var timerInterval = 200;
    var $area;
    var offset = 0;
    var boxes = [];
    var timers = [];
    var isPaused = false;
    var timerId = false;

    var timerClock = function () {
        if (isPaused) {
            return;
        }
        for (var i = 0; i < timers.length; ++i) {
            (timers[i] -= timerInterval) <= 0 && this.close(i--);
        }
    }

    // Public Properties

    var Minipopup = {
        space: 20,
        defaults: {
            // info
            message: '',
            productClass: '', // ' product-cart', ' product-list-sm'
            imageSrc: '',
            imageLink: '#',
            name: '',
            nameLink: '#', // 'product.html',
            price: '',
            count: null,
            rating: null,

            // option
            delay: 4000, // milliseconds

            // template
            priceTemplate: '<span class="product-price">{{price}}</span>',
            ratingTemplate: '<div class="ratings-container"><div class="ratings-full"><span class="ratings" style="width:{{rating}}"></span><span class="tooltiptext tooltip-top"></span></div></div>',
            priceQuantityTemplate: '<div class="price-box"><span class="product-quantity">{{count}}</span><span class="product-price">{{price}}</span></div>',

            template: '<div class="minipopup-box"><p class="minipopup-title">{{message}}</p>' +
                '<div class="product {{productClass}} mb-0">' +
                '<figure class="product-media"><a href="{{imageLink}}"><img src="{{imageSrc}}" alt="product" width="90" height="90"></a></figure>' +
                '<div class="product-detail">' +
                '<a href="{{nameLink}}" class="product-name">{{name}}</a>' +
                '{{detailTemplate}}' +
                '</div>' +
                '</div></div>',
        },

        init: function () {
            // init area
            var area = document.createElement('div');
            area.className = "minipopup-area";
            Donald.byClass('page-wrapper')[0].appendChild(area);

            $area = $(area);
            $area.on('click', '.btn-close', function (e) {
                self.close($(this).closest('.minipopup-box').index());
            });

            // bind methods
            this.close = this.close.bind(this);
            timerClock = timerClock.bind(this);
        },

        open: function (options, callback) {
            var self = this,
                settings = $.extend(true, {}, self.defaults, options),
                $box;

            settings.detailTemplate = Donald.parseTemplate(
                (null != settings.count ? settings.priceQuantityTemplate : settings.priceTemplate),
                settings
            )
            if (null != settings.rating) {
                settings.detailTemplate += Donald.parseTemplate(settings.ratingTemplate, settings);
            }
            $box = $(Donald.parseTemplate(settings.template, settings));

            // open
            $box
                .appendTo($area)
                .css('top', - offset)
                .find("img")[0]
                .onload = function () {
                    offset += $box[0].offsetHeight + self.space;

                    $box.addClass('show');
                    if ($box.offset().top - window.pageYOffset < 0) {
                        self.close();
                        $box.css('top', - offset + $box[0].offsetHeight + self.space);
                    }
                    $box.on('mouseenter', function () {
                        self.pause();
                    });
                    $box.on('mouseleave', function () {
                        self.resume();
                    });
                    $box.on('touchstart', function (e) {
                        self.pause();
                        e.stopPropagation();
                    });
                    Donald.$body.on('touchstart', function () {
                        self.resume();
                    });

                    boxes.push($box);
                    timers.push(settings.delay);

                    (timers.length > 1) || (
                        timerId = setInterval(timerClock, timerInterval)
                    );

                    callback && callback($box);
                };
        },

        close: function (indexToClose) {
            var self = this,
                index = ('undefined' === typeof indexToClose) ? 0 : indexToClose,
                $box = boxes.splice(index, 1)[0];

            // remove timer
            timers.splice(index, 1)[0];

            // remove box
            offset -= $box[0].offsetHeight + self.space;
            $box.removeClass('show');
            setTimeout(function () {
                $box.remove();
            }, 300);

            // slide down other boxes
            boxes.forEach(function ($box, i) {
                if (i >= index && $box.hasClass('show')) {
                    $box.stop(true, true).animate({
                        top: parseInt($box.css('top')) + $box[0].offsetHeight + 20
                    }, 600, 'easeOutQuint');
                }
            });

            // clear timer
            boxes.length || clearTimeout(timerId);
        },

        pause: function () {
            isPaused = true;
        },

        resume: function () {
            isPaused = false;
        }
    }

    Donald.minipopup = Minipopup;

})(jQuery);
