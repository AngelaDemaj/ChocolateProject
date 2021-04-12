"use strict";

window.Donald = Donald || {};

(function ($) {
    var requestAnimFrame =
        window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        function (callback) {
            window.setTimeout(callback, 1000 / 60);
        };

    function cubicInOut(a) {
        return .5 > a ? 4 * a * a * a : .5 * Math.pow(2 * a - 2, 3) + 1;
    }

    function FloatSVG(svg, options) {
        this.options = $.extend({
            delta: 15,
            speed: 10
        }, options);
        this.el = svg;
        this.$el = $(svg);
        this.start();
    }

    FloatSVG.prototype.getDeltaY = function (dx) {
        return Math.sin(2 * Math.PI * dx / this.width) * this.options.delta;
    }

    FloatSVG.prototype.start = function () {
        var updateFn = this.update.bind(this);

        this.timeStart = Date.now() - parseInt(Math.random() * 100);
        this.$el.find('path').each(function () {
            $(this).data('original', this.getAttribute('d').replace(/([\d])\s*\-/g, '$1,-'));
        });

        window.addEventListener('resize', updateFn, { passive: true });
        window.addEventListener('scroll', updateFn, { passive: true });
        this.update();
    }

    FloatSVG.prototype.update = function () {
        var self = this;
        if (Donald.isOnScreen(this.el)) {
            requestAnimFrame(function () {
                self.draw();
            });
        }
    }

    FloatSVG.prototype.draw = function () {
        var self = this,
            _dx = (Date.now() - this.timeStart) * this.options.speed / 100;

        this.width = this.$el.width();
        this.$el.find('path').each(function () {
            var dx = _dx, dy = 0;
            this.setAttribute('d', $(this).data('original')
                .replace(/M([\d|\.]*),([\d|\.]*)/g, function (match, p1, p2) {
                    return 'M' + p1 + ',' + (parseFloat(p2) + (dy = self.getDeltaY(dx += parseFloat(p1)))).toFixed(3);
                })
                .replace(/([c|C])[^A-Za-z]*/g, function (match, p1) {
                    var v = match.slice(1).split(',').map(parseFloat);

                    if ('C' == p1) {
                        v[1] += self.getDeltaY(_dx + v[0]);
                        v[3] += self.getDeltaY(_dx + v[2]);
                        v[5] += self.getDeltaY(dx = _dx + v[4]);
                    } else {
                        v[1] += self.getDeltaY(dx + v[0]) - dy;
                        v[3] += self.getDeltaY(dx + v[2]) - dy;
                        v[5] += self.getDeltaY(dx += v[4]) - dy;
                    }
                    dy = self.getDeltaY(dx);

                    return p1 + v.map(function (v) {
                        return v.toFixed(3);
                    }).join(',');
                })
            );
        });

        this.update();
    }

    Donald.floatSVG = function (selector, options) {
        Donald.$(selector).each(function () {
            new FloatSVG(this, options);
        })
    }

    function FloatEl(el, options) {
        this.el = el;
        this.options = $.extend({
            delta: 5,
            max: 30,
            delay: 1500,
        }, options, Donald.parseOptions(el.getAttribute('data-float-options')));

        this._x = 0;
        this._y = 0;

        var self = this,
            runFloat = function () {
                Donald.call(self.update.bind(self), self.options.delay);
            }

        if (this.el.classList.contains('appear-animate')) {
            $(this.el).data('appear-callback', runFloat);
        } else {
            runFloat();
        }
    }

    FloatEl.prototype.update = function () {
        var self = this;
        setTimeout(function () {
            self.move();
        }, 1000)
    }

    FloatEl.prototype.move = function () {
        var angle, dx, dy;
        do {
            angle = 2 * Math.PI * Math.random();
            dx = Math.cos(angle) * this.options.delta;
            dy = Math.sin(angle) * this.options.delta;
        } while ((this._x + dx) * (this._x + dx) + (this._y + dy) * (this._y + dy) > this.options.max * this.options.max);
        this.el.style.transform = 'translate(' + (this._x += dx) + 'px,' + (this._y += dy) + 'px)';
        this.update();
    }

    Donald.floatEl = function (selector, options) {
        Donald.$(selector).each(function () {
            new FloatEl(this, options);
        })
    }

    function Particle(el, options) {
        this.el = el;
        this.$el = $(el);
        this.options = $.extend({
            count: 10,
            space: 12
        }, options);
        this.init();
    }

    Particle.prototype.init = function () {
        for (var i = 0; i < this.options.count; ++i) {
            var span = document.createElement('span');
            span.style['animation-delay'] = (i * 100) + 'ms';
            span.style['top'] = i * this.options.space + 'px';
            this.el.appendChild(span);
        }
    }

    Donald.particles = function (selector, options) {
        Donald.$(selector).each(function () {
            new Particle(this, options);
        })
    }

    function ShapeOverlay(el, options) {
        this.el = el;
        this.$el = $(el);
        this.options = $.extend({
            layersCount: 4,
            duration: 800,
            delay: 70,
            delayMax: 180,
            fill: '',
            fillMode: '',
            gradient: '',
            color: [46, 102, 232]
        }, options);
        this.init();
    }

    ShapeOverlay.prototype.init = function () {
        this.isAnimating = false;
        this.status = '';
        this.delays = [];

        this.$el
            .on('mouseenter touchstart', this.start.bind(this))
            .on('mouseleave touchend', this.finish.bind(this));

        this.path = this.el.getElementsByClassName('overlay-path');
    }

    ShapeOverlay.prototype.start = function () {
        if (this.status == '') {
            var i, svg = '';
            svg += '<svg class="shape-overlays" viewBox="0 0 100 100" preserveAspectRatio="none"';
            if (this.options.fill) {
                svg += ' fill="' + this.options.fill + '"';
            }
            svg += '>' + this.options.gradient;
            for (i = 0; i < this.options.layersCount; ++i) {
                svg += '<path opacity="' + (i + 1) / this.options.layersCount + '" class="overlay-path" />';
                this.delays[i] = (Math.sin(2 * Math.PI * (Math.random() + i / (this.options.layersCount))) + 1) / 2 * this.options.delayMax;
            }
            this.$el.append(svg += '</svg>');

            this.status = 'opening';
            this.timeStart = Date.now();
            this.update();
        }
    }

    ShapeOverlay.prototype.finish = function () {
        if (this.status == 'opening') {
            this.status = 'opening-close';
        } else if (this.status == 'opened') {
            if (this.options.fillMode == 'onlyshape') {
                this.$el.find('.shape-overlays').remove();
                this.status = '';
            } else {
                this.status = 'closing';
                this.timeStart = Date.now();
                this.update();
            }
        }
    }

    ShapeOverlay.prototype.update = function () {
        if (Date.now() < this.timeStart + this.options.duration + this.options.delay * (this.options.layersCount - 1) + this.options.delayMax) {
            var self = this;
            requestAnimFrame(function () {
                self.draw();
            });
        }
        else {
            if (this.options.fillMode == 'onlyshape') {
                this.$el.find('.shape-overlays').remove();
                this.status = '';
            } else {
                if (this.status == 'opening') {
                    this.status = 'opened';
                } else if (this.status == 'opening-close') {
                    this.status = 'closing';
                    this.timeStart = Date.now();
                    this.update();
                } else if (this.status == 'closing') {
                    this.$el.find('.shape-overlays').remove();
                    this.status = '';
                }
            }
            this.isAnimating = false;
        }
    }

    ShapeOverlay.prototype.draw = function () {
        for (var i = 0; i < this.options.layersCount; ++i) {
            this.path[i].setAttribute('d', this.updatePath(Date.now() - this.timeStart - this.options.delay * (this.status.startsWith('opening') ? i : this.options.layersCount - i - 1)));
        }
        this.update();
    }

    ShapeOverlay.prototype.updatePath = function (time) {
        var points = [], p, cp, str = '';
        for (var i = 0; i < this.options.layersCount; ++i) {
            points[i] = cubicInOut(Math.min(Math.max(time - this.delays[i], 0) / this.options.duration, 1)) * 100
        }

        str += this.status.startsWith('opening') ? 'M 0 0 V ' + points[0].toFixed(2) + ' ' : 'M 0 ' + points[0].toFixed(2) + ' ';
        for (var i = 0; i < this.options.layersCount - 1; ++i) {
            p = (i + 1) / (this.options.layersCount - 1) * 100;
            cp = p - (1 / (this.options.layersCount - 1) * 100) / 2;
            str += 'C ' + cp.toFixed(2) + ' ' + points[i].toFixed(2) + ' ' + cp.toFixed(2) + ' ' + points[i + 1].toFixed(2) + ' ' + p.toFixed(2) + ' ' + points[i + 1].toFixed(2) + ' ';
        }
        str += this.status.startsWith('opening') ? 'V 0 H 0' : 'V 100 H 0';
        return str;
    }

    Donald.shapeOverlay = function (selector, options) {
        Donald.$(selector).each(function () {
            new ShapeOverlay(this, options);
        })
    }

    function FloatBackground(el, options) {
        var updateFn = this.update.bind(this);

        this.el = el;
        this.options = $.extend({
            friction: .03
        }, options);
        this.x2 = this.y2 = this.x = this.y = 0;

        $(window).on('mousemove click', this.moveTo.bind(this));
        window.addEventListener('resize', updateFn, { passive: true });
        window.addEventListener('scroll', updateFn, { passive: true });
        this.update();
    }

    FloatBackground.prototype.update = function () {
        var self = this;
        if (Donald.isOnScreen(this.el)) {
            requestAnimFrame(function () {
                self.move();
            });
        }
    }

    FloatBackground.prototype.moveTo = function (e) {
        this.x2 = -0.1 * e.clientX;
        this.y2 = -0.1 * e.clientY;
    }

    FloatBackground.prototype.move = function () {
        this.x += (this.x2 - this.x) * this.options.friction;
        this.y += (this.y2 - this.y) * this.options.friction;
        this.el.style['background-position'] = parseInt(this.x) + 'px ' + parseInt(this.y) + 'px';
        this.update();
    }

    Donald.floatBackground = function (selector, options) {
        Donald.$(selector).each(function () {
            new FloatBackground(this, options);
        })
    }

    Donald.scrollTo = function (arg, duration) {
        var offset = 0;
        var _duration = typeof duration == 'undefined' ? 600 : duration;
        if (typeof arg == 'number') {
            offset = arg;
        } else {
            offset = Donald.$(arg).offset().top;
        }
        $('html,body').stop().animate({ scrollTop: offset }, _duration);
    }

    $(window).on('donald_complete', function () {
        Donald.floatBackground('.float-bg'); // issue : if visible
        Donald.floatSVG('.expshape1', { speed: 5 });
        Donald.floatSVG('.expshape2', { speed: 4 });
        Donald.floatEl('.float-el');
        Donald.particles('.particle1');
        Donald.particles('.particle2', {
            space: 20,
            count: 13
        });
        Donald.shapeOverlay('.shape-overlay', {
            fill: 'url(#bg-gradient)',
            gradient: '<defs><linearGradient id="bg-gradient" y2="100%"><stop offset="0" stop-color="#08c"/><stop offset="100%" stop-color="#5349ff"/></linearGradient></defs>'
        });
        $('.demos .appear-animate, .features .appear-animate').each(function () {
            this.setAttribute('data-animation-options', "{'name':'fadeInUpShorter','duration':'.5s','delay':'" + parseInt(Math.random() * 3) / 10 + "s'}");
        });

        Donald.$body.on('click', '.main-nav a, .mobile-menu a, .scroll-to', function (e) {
            var link = e.currentTarget, hash = link.hash ? link.hash : link.slice(link.lastIndexOf('#'));
            if (hash.startsWith('#')) {
                $('.mobile-menu-overlay').click();
                Donald.scrollTo(hash);
                e.preventDefault();
            }
        })

        Donald.lazyload(document.body);
        Donald.playableVideo('.video-banner');
    });
})(jQuery);