﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SistemaBico.Web.Util
{
    public class ConvertGeneric
    {
        private const int HEIGHT = 120;
        private const int WIDTH = 120;
        private const string IMAGEDEFAULT = "/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAABkAAD/4QMvaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzE0MiA3OS4xNjA5MjQsIDIwMTcvMDcvMTMtMDE6MDY6MzkgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE4IChXaW5kb3dzKSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo2M0U3NTM2MkQ0NEUxMUU4Qjk0OEE5MzM2RDU3RENEMiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo2M0U3NTM2M0Q0NEUxMUU4Qjk0OEE5MzM2RDU3RENEMiI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjYzRTc1MzYwRDQ0RTExRThCOTQ4QTkzMzZENTdEQ0QyIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjYzRTc1MzYxRDQ0RTExRThCOTQ4QTkzMzZENTdEQ0QyIi8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+/+4ADkFkb2JlAGTAAAAAAf/bAIQAAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQICAgICAgICAgICAwMDAwMDAwMDAwEBAQEBAQECAQECAgIBAgIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMD/8AAEQgAZABkAwERAAIRAQMRAf/EAaIAAAAGAgMBAAAAAAAAAAAAAAcIBgUECQMKAgEACwEAAAYDAQEBAAAAAAAAAAAABgUEAwcCCAEJAAoLEAACAQMEAQMDAgMDAwIGCXUBAgMEEQUSBiEHEyIACDEUQTIjFQlRQhZhJDMXUnGBGGKRJUOhsfAmNHIKGcHRNSfhUzaC8ZKiRFRzRUY3R2MoVVZXGrLC0uLyZIN0k4Rlo7PD0+MpOGbzdSo5OkhJSlhZWmdoaWp2d3h5eoWGh4iJipSVlpeYmZqkpaanqKmqtLW2t7i5usTFxsfIycrU1dbX2Nna5OXm5+jp6vT19vf4+foRAAIBAwIEBAMFBAQEBgYFbQECAxEEIRIFMQYAIhNBUQcyYRRxCEKBI5EVUqFiFjMJsSTB0UNy8BfhgjQlklMYY0TxorImNRlUNkVkJwpzg5NGdMLS4vJVZXVWN4SFo7PD0+PzKRqUpLTE1OT0laW1xdXl9ShHV2Y4doaWprbG1ub2Z3eHl6e3x9fn90hYaHiImKi4yNjo+DlJWWl5iZmpucnZ6fkqOkpaanqKmqq6ytrq+v/aAAwDAQACEQMRAD8A29/Yp6Keve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917oMe0u1dudU4IZXNs9TW1Zkhw+GpmUVmTqY0DMFLXWnpIdS+WZgVQMAAzMqtdVLGg62BXqujd3ya7W3RVStR5xtrY4uTBjtvotM0SfRRLkmVsjPJb9R8ioTyEX6e3xGo+fVwo6SeM7z7cxNQlTT7/ANxzsj6/Hk658xTtzcq9PlBWQsh/pbj8W970IfLrdB0dHpT5QUu866k2rviClxO4atkp8ZlqXVFisvUEWSlnikZv4dXzEWT1GKVzpGhiqs08dMrw6oVpkdHA9s9V697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3XuqdO8d81W/eyNw5KSZpMdjqyfCYOK58UOLxs8sETxqSQGrZQ87n8tJ/QABWi6V6dAoOgi93631737r3XJHaNldGZHRg6OhKsjKQVZWBBVlIuCPp791rq4noze1Rv7rPb2cr5PLlYY5sRl5P7UtfjJPt2qH5P7lZTCOZvxqkNvaRxpanl02RQ9C77p1rr3v3Xuve/de697917r3v3Xuve/de697917ro8gi5Fx9R9R/iP8ffuvdUW52jqMdm8xj6tWWqocpkKOpVxZxPTVcsMwcf6oSIb+1o4dO9NXvfW+ve/de697917q0T4h0VRS9TPPMHEeR3RmKyk1CytTpBjqBnT8lTU0Ug/wBce00vxfl023Ho0ntrqvXvfuvde9+691737r3Xvfuvde9+691737r3XvfuvdVwfKjp6uw+equx8FSPUYLNyLLuCOnjd2xGXICS1s6qDpocoQHMn0WoLBra0uoieo0nj1dT5dE29vdX697917pZ7C2Jn+xdx0W3Nv0zSz1Dq1XWMjmjxdEGAnr6+VQRFBCv0H6pGsigsQPdWYKKnrRNOrk9pbZx2zttYXa+KUigwtDDRQswAkmZAXnqZbXHmq6h3le3Gtz7SE1NT02c9KL3rrXXvfuvde9+691737r3Xvfuvde9+691737r3THuDcu39q4+TK7jzFBhsfHe9TX1CQK7AX8UKMfJUTN+EjDO34B97AJwOvdAHUfKjpmor1ws1ZlKugrddJU5KXBSthFilvE61kdSyV0lNIpIa1M66Tzxf254T8eraT0y5z4w9Rb9jXcGz8nNhYK8iaObbVZSZLAzalBYw0kvmSD630QyxohNtI+nvwkZcHr2ojpjxfwu2hT1KS5fd2fydMrampaSkocYZB+EedjkHC/10hSfwR72Zj5Dr2o9LKo7L6H6Eij2vhUj+5Z0/iNLtiCLMZBZI1CCozuSnq4hJUKCf23meVAeIwtvetLvk9eoTnoTdldx9c9gSCm23uSlmyJF/wCFVqS43Jm318NJWpC1UF/JhMgH5PurIy8etEEdCf7p1rr3v3Xuve/de697917r3v3Xuve/de6DntLsjEdX7Tq9x5MCoqC32eHxqvplyeUljkeCmDcmOBFjLzSWOiNSQC2lTZVLGg62BU9VG7335ufsLNS53dGRkraptSU0C3jocdTFiy0mPpQxjpqdP8Ls59TszEkqlUKKDpwCnDpH+7db6esPuPcG3pGmwOcy+FlY3d8XkaugLkcfufazReTgfm/vRAPHrXT1k+x+wM1AabK713TX0zLpenqc7kpIHW1tMkRqPHILf1B96CqOAHXqDpF+7db65xSyQSRzQyPDNE6yRSxO0ckUiMGSSN0IZHRgCCCCD791rqxX429/1e6pothb3rPuM8I2O3s1NYS5eKniMkuPr34EmShijLxynmdAQ37gBkTyJTuHDqjDzHR0PbPVeve/de697917r3v3Xuve/de6Jr8vthZ7P4LDbuxUlTWUO1UrI8tiYwziCkrWids3FGvLfbmAJPwSsZVuFVz7eiYA0Pn1ZT1XD7UdOde9+691737r3Xvfuvde9+691737r3Q29B9fZ3fXYGHkxklTj8ftyuos1l83AGX7CKjnWenghltp++r5YfHEvPGpyCqN7o7BVz1Umg6t79pOm+ve/de697917r3v3Xuve/de64OiSo8UqLJHIrJJG6h0dHBV0dGBVlZTYg8Ee/de6r17t+LlfQVNXujrOjevxkzSVNftWGzVuOdjrkfCxmzVtCbkinF5ovogdbBFCSVw3Hq4b16JRLFLBLJDPHJDNC7RyxSo0csUiMVeOSNwHR0YWIIBB9vdW6x+/db697917r3v3Xuhj6t6R3l2jVwyY+kfGbcWYJXblromShjRWHljoUJR8nWAcCOP0q1tboDf3RnC8ePVSQOrUNg7C291xt2m25t2mMVNETNVVc2l63JVrqomrq6ZVXyTSaQAAAqIAqgKAPaZmLGp6oTU16WvuvWuve/de697917r3v3Xuve/de697917r3v3Xug03r1D152AGfcm3KOauYC2Wo9WPyykfTVXUhilqFH+pl8if4e7BmXh1sEjovWV+F20aiZ3w+78/jYW5WCtpKDK+Mn8CSL+GMyj8Xuf8fbnjHzHW9R6a6b4T4pGvWdg5CdL8rTbepqRtN/pqlytaL2/Nv8AYe9+MfTreroXtp/GDqfa00NXLiqrctbCAVm3JUrW04kBB1jGwQ0uOfkcCSOS3+vz7oZGPWixPRgYIIKaGOnpoYqenhRY4YII0ihijUWVI4owqIij6AAAe6dV6y+9de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuve/de697917r3v3Xuv/9k=";
        public static byte[] IFormFileToBase64(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                using (var img = Image.FromStream(ms))
                {
                    if (img.Height > HEIGHT || img.Width > WIDTH)
                        return ReduceImage(img, file);
                }

                return ms.ToArray();
            }
        }

        #region ImageResize
        private static byte[] ReduceImage(Image image, IFormFile file)
        {
            using (var memory = new MemoryStream())
            {
                var img = ResizeImage(image, WIDTH, HEIGHT);
                img.Save(memory, ImageFormat.Jpeg);
                file.CopyTo(memory);

                return memory.ToArray();
            }
        }

        //private static Bitmap ResizeImage(Image image, int width, int height)
        //{
        //    var destRect = new Rectangle(0, 0, width, height);
        //    var destImage = new Bitmap(width, height);

        //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    using (var graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);

        //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    return destImage;
        //}
        public static Image ResizeImage(Image image, int width, int height)
        {
            var destinationRect = new Rectangle(0, 0, width, height);
            var destinationImage = new Bitmap(width, height);

            destinationImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destinationImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destinationRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (Image)destinationImage;
        }
        #endregion
    }
}
