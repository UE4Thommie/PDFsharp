using PdfSharp.Pdf.Annotations.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfSharp.Pdf.Annotations
{
    public sealed class PdfSquareCircleAnnotation : PdfAnnotation
    {
        public static string TYPE_SQUARE = "/Square";
        public static string TYPE_Circle = "/Circle";

        private PdfBorderStyle _borderStyle;
        private PdfBorderEffect _borderEffect;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfSquareCircleAnnotation"/> class.
        /// </summary>
        public PdfSquareCircleAnnotation()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfSquareCircleAnnotation"/> class.
        /// </summary>
        /// <param name="document"></param>
        public PdfSquareCircleAnnotation(PdfDocument document)
            : base(document)
        {
            Initialize();
        }

        void Initialize()
        {
            Elements.SetName(Keys.Subtype, TYPE_SQUARE);
            _borderStyle = new PdfBorderStyle();
            _borderEffect = new PdfBorderEffect();
        }

        /// <summary>
        /// Get or set annotation type using the public constants.>
        /// </summary>
        public void SetType(string type)
        {
            if (type.Equals(TYPE_SQUARE))
                Elements.SetName(Keys.Subtype, TYPE_SQUARE);
            else if (type.Equals(TYPE_Circle))
                Elements.SetName(Keys.Subtype, TYPE_Circle);
        }

        /// <summary>
        /// Get or set border style. <see cref="PdfBorderStyle"/>
        /// </summary>
        public PdfBorderStyle BorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                _borderStyle = value;
                Elements[Keys.BS] = _borderStyle;
            }
        }

        /// <summary>
        /// Get or set border effect. <see cref="PdfBorderEffect"/>
        /// </summary>
        public PdfBorderEffect BorderEffect
        {
            get
            {
                return _borderEffect;
            }
            set
            {
                _borderEffect = value;
                Elements[Keys.BE] = _borderEffect;
            }
        }


        /// <summary>
        /// Predefined keys of this dictionary.
        /// </summary>
        internal new class Keys : PdfAnnotation.Keys
        {
            // @TODO add IC for fill colour

            /// <summary>
            /// (Optional; PDF 1.5) Begining with PDF 1.5, some annotations (square, circle and polygon) may have
            /// a BE entry, which is a border effect dictionary that specifies an effect to be applied
            /// to the border of the annotations.
            /// </summary>
            [KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
            public const string BE = "/BE";
        }
    }
}
