using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Linq;

namespace SS_OpenCV
{
    class ImageClass
    {

        /// <summary>
        /// Image Negative using EmguCV library
        /// Slower method
        /// </summary>
        /// <param name="img">Image</param>
        public static void OldNegative(Image<Bgr, byte> img)
        {
            int x, y;

            Bgr aux;
            for (y = 0; y < img.Height; y++)
            {
                for (x = 0; x < img.Width; x++)
                {
                    // acesso directo : mais lento 
                    aux = img[y, x];
                    img[y, x] = new Bgr(255 - aux.Blue, 255 - aux.Green, 255 - aux.Red);
                }
            }
        }


        public static void Negative(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to negative
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            // store in the image
                            dataPtr[0] = (byte)(255 - blue);
                            dataPtr[1] = (byte)(255 - green);
                            dataPtr[2] = (byte)(255 - red);

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        /// <summary>
        /// Convert to gray
        /// Direct access to memory - faster method
        /// </summary>
        /// <param name="img">image</param>
        public static void ConvertToGray(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Red(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)red + red + red) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Green(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)green + green + green) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Blue(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + blue + blue) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void BrightContrast(Image<Bgr, byte> img, int brightness, double contrast)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            byte blueAux = (byte)(blue * contrast + brightness);
                            byte greenAux = (byte)(green * contrast + brightness);
                            byte redAux = (byte)(red * contrast + brightness);

                            // store in the image
                            dataPtr[0] = (byte)(blueAux < 0 ? 0 : blueAux > 255 ? 255 : blueAux);
                            dataPtr[1] = (byte)(greenAux < 0 ? 0 : greenAux > 255 ? 255 : greenAux);
                            dataPtr[2] = (byte)(redAux < 0 ? 0 : redAux > 255 ? 255 : redAux);

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Translation(Image<Bgr, byte> imgDestino, Image<Bgr, byte> imgOrigem, int dx, int dy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = imgDestino.MIplImage;
                MIplImage mo = imgOrigem.MIplImage;
                // ptr destino -> imagem normal
                byte* dataPtr_dest = (byte*)m.imageData.ToPointer();
                // ptr origem -> imagem copia
                byte* dataPtr_orig = (byte*)mo.imageData.ToPointer();
                byte blue, green, red;

                int width = imgOrigem.Width;
                int height = imgOrigem.Height;
                int nChan = m.nChannels; // number of channels - 3
                int x, y, xO, yO;
                int whidthstep = m.widthStep;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            xO = x - dx;
                            yO = y - dy;

                            if (xO > width - 1 || yO > height - 1 || xO < 0 || yO < 0)
                            {
                                blue = 0;
                                green = 0;
                                red = 0;
                            }
                            else
                            {
                                blue = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[0];
                                green = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[1];
                                red = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[2];
                            }

                            (dataPtr_dest + y * whidthstep + x * nChan)[0] = blue;
                            (dataPtr_dest + y * whidthstep + x * nChan)[1] = green;
                            (dataPtr_dest + y * whidthstep + x * nChan)[2] = red;

                        }
                    }
                }
            }
        }


        public static void Rotation(Image<Bgr, byte> imgDestino, Image<Bgr, byte> imgOrigem, float angle)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = imgDestino.MIplImage;
                MIplImage mo = imgOrigem.MIplImage;
                // ptr destino -> imagem normal
                byte* dataPtr_dest = (byte*)m.imageData.ToPointer();
                // ptr origem -> imagem copia
                byte* dataPtr_orig = (byte*)mo.imageData.ToPointer();
                byte blue, green, red;

                int width = imgOrigem.Width;
                int height = imgOrigem.Height;
                int nChan = m.nChannels; // number of channels - 3
                int x, y, xO, yO;
                int whidthstep = m.widthStep;

                double xCenter = imgOrigem.Width / 2.0;
                double yCenter = imgOrigem.Height / 2.0;
                double cosAngle = Math.Cos(angle);
                double sinAngle = Math.Sin(angle);

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            xO = (int)Math.Round((x - xCenter) * cosAngle - (yCenter - y) * sinAngle + xCenter);
                            yO = (int)Math.Round(yCenter - (x - xCenter) * sinAngle - (yCenter - y) * cosAngle);

                            if (xO > width - 1 || yO > height - 1 || xO < 0 || yO < 0)
                            {
                                blue = 0;
                                green = 0;
                                red = 0;
                            }
                            else
                            {
                                blue = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[0];
                                green = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[1];
                                red = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[2];
                            }

                            (dataPtr_dest + y * whidthstep + x * nChan)[0] = blue;
                            (dataPtr_dest + y * whidthstep + x * nChan)[1] = green;
                            (dataPtr_dest + y * whidthstep + x * nChan)[2] = red;

                        }
                    }
                }
            }
        }

        public static void Scale(Image<Bgr, byte> imgDestino, Image<Bgr, byte> imgOrigem, float scaleFactor)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = imgDestino.MIplImage;
                MIplImage mo = imgOrigem.MIplImage;
                // ptr destino -> imagem normal
                byte* dataPtr_dest = (byte*)m.imageData.ToPointer();
                // ptr origem -> imagem copia
                byte* dataPtr_orig = (byte*)mo.imageData.ToPointer();
                byte blue, green, red;

                int width = imgOrigem.Width;
                int height = imgOrigem.Height;
                int nChan = m.nChannels; // number of channels - 3
                int x, y, xO, yO;
                int whidthstep = m.widthStep;
                //Esta funçao tem um erro, caso o Xo e Yo sejam 1.34 ou seja com decimas, temos que fazer interpolaçao bilinear
                //double xCenter = imgOrigem.Width / 2.0;
                //double yCenter = imgOrigem.Height / 2.0;
                //double w2 = xCenter / (scaleFactor), h2 = yCenter / (scaleFactor);


                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //xO = (int)Math.Round(x / scaleFactor + xCenter - w2);
                            //yO = (int)Math.Round(y / scaleFactor + yCenter - h2);
                            xO = (int)Math.Round(x / scaleFactor);
                            yO = (int)Math.Round(y / scaleFactor);

                            if (xO > width - 1 || yO > height - 1 || xO < 0 || yO < 0)
                            {
                                blue = 0;
                                green = 0;
                                red = 0;
                            }
                            else
                            {
                                blue = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[0];
                                green = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[1];
                                red = (byte)(dataPtr_orig + yO * whidthstep + xO * nChan)[2];
                            }

                            (dataPtr_dest + y * whidthstep + x * nChan)[0] = blue;
                            (dataPtr_dest + y * whidthstep + x * nChan)[1] = green;
                            (dataPtr_dest + y * whidthstep + x * nChan)[2] = red;

                        }
                    }
                }
            }
        }


        /// <summary>
        /// Implements the inverse scale (zoom)
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgCopy"></param>
        /// <param name="angle"></param>
        public static void Scale_point_xy(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor, int dx, int dy)
        {
            unsafe
            {
                // acesso directo à memoria da imagem (sequencial)
                // top left to bottom right
                MIplImage m = img.MIplImage;
                MIplImage mo = imgCopy.MIplImage;
                // ptr destino -> imagem normal
                byte* dataPtr_dest = (byte*)m.imageData.ToPointer();
                // ptr origem -> imagem copia
                byte* dataPtr_orig = (byte*)mo.imageData.ToPointer();
                byte* dataPtr_orig_aux;
                int h = img.Height;
                int w = img.Width;
                int xd, yd, xo, yo;
                int nC = m.nChannels;
                int wStep = m.widthStep - m.nChannels * m.width;
                int mwidthStep = m.widthStep;
                float w2 = (w / 2) / (scaleFactor), h2 = (h / 2) / (scaleFactor);

                if (nC == 3)
                {
                    for (yd = 0; yd < h; yd++)
                    {
                        for (xd = 0; xd < w; xd++)
                        {
                            // get original coordinates
                            xo = (int)Math.Round(xd / scaleFactor + dx - w2);
                            yo = (int)Math.Round(yd / scaleFactor + dy - h2);

                            if (xo >= 0 && xo < w && yo >= 0 && yo < h)
                            {
                                // get pointer to pixel
                                // ptr origem -> imagem copia
                                // ptr destino -> imagem normal
                                dataPtr_orig_aux = dataPtr_orig + yo * mwidthStep + xo * nC;

                                dataPtr_dest[0] = dataPtr_orig_aux[0];
                                dataPtr_dest[1] = dataPtr_orig_aux[1];
                                dataPtr_dest[2] = dataPtr_orig_aux[2];

                            }
                            else
                            { // outside the image -> fill with black
                                dataPtr_dest[0] = 0;
                                dataPtr_dest[1] = 0;
                                dataPtr_dest[2] = 0;
                            }
                            // avança apontador 
                            dataPtr_dest += nC;
                        }

                        //no fim da linha avança alinhamento
                        dataPtr_dest += wStep;
                    }
                }
            }
        }
        public static void Mean(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* resetPtr = dataPtr;
                byte* dataPtrBorder = dataPtr;
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Pointer to the image
                byte* resetPtrCopy = dataPtrCopy;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int blueSum = 0, greenSum = 0, redSum = 0;
                int nC = m.nChannels;

                dataPtrCopy += nChan + widthStep;
                dataPtr += nChan + widthStep;
                if (nC == 3)
                {
                    for (y = 1; y < height - 1; y++)
                    {
                        for (x = 1; x < width - 1; x++)
                        {
                            blueSum = dataPtrCopy[0] + (dataPtrCopy - nChan)[0] + (dataPtrCopy + nChan)[0];
                            greenSum = dataPtrCopy[1] + (dataPtrCopy - nChan)[1] + (dataPtrCopy + nChan)[1];
                            redSum = dataPtrCopy[2] + (dataPtrCopy - nChan)[2] + (dataPtrCopy + nChan)[2];

                            blueSum += (dataPtrCopy - widthStep)[0] + (dataPtrCopy - widthStep - nChan)[0] + (dataPtrCopy - widthStep + nChan)[0];
                            greenSum += (dataPtrCopy - widthStep)[1] + (dataPtrCopy - widthStep - nChan)[1] + (dataPtrCopy - widthStep + nChan)[1];
                            redSum += (dataPtrCopy - widthStep)[2] + (dataPtrCopy - widthStep - nChan)[2] + (dataPtrCopy - widthStep + nChan)[2];

                            blueSum += (dataPtrCopy + widthStep)[0] + (dataPtrCopy + widthStep - nChan)[0] + (dataPtrCopy + widthStep + nChan)[0];
                            greenSum += (dataPtrCopy + widthStep)[1] + (dataPtrCopy + widthStep - nChan)[1] + (dataPtrCopy + widthStep + nChan)[1];
                            redSum += (dataPtrCopy + widthStep)[2] + (dataPtrCopy + widthStep - nChan)[2] + (dataPtrCopy + widthStep + nChan)[2];

                            if (Math.Round(blueSum / 9.0) > 255)
                                dataPtr[0] = 255;
                            else
                                dataPtr[0] = (byte)Math.Round(blueSum / 9.0);

                            if (Math.Round(greenSum / 9.0) > 255)
                                dataPtr[1] = 255;
                            else
                                dataPtr[1] = (byte)Math.Round(greenSum / 9.0);

                            if (Math.Round(redSum / 9.0) > 255)
                                dataPtr[2] = 255;
                            else
                                dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }

                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    dataPtrBorder = resetPtrCopy;
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder + nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder + nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder + nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2];

                    if (Math.Round(blueSum / 9.0) > 255)
                        dataPtr[0] = 255;
                    else
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    if (Math.Round(greenSum / 9.0) > 255)
                        dataPtr[1] = 255;
                    else
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    if (Math.Round(redSum / 9.0) > 255)
                        dataPtr[2] = 255;
                    else
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                    //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    //dataPtr[0] = 255;
                    //dataPtr[1] = 0;
                    //dataPtr[2] = 0;

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder + nChan)[0] + (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder + nChan)[1] + (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder - nChan + widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder + nChan)[2] + (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder - nChan + widthStep)[2];

                        if (Math.Round(blueSum / 9.0) > 255)
                            dataPtr[0] = 255;
                        else
                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        if (Math.Round(greenSum / 9.0) > 255)
                            dataPtr[1] = 255;
                        else
                            dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        if (Math.Round(redSum / 9.0) > 255)
                            dataPtr[2] = 255;
                        else
                            dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                        //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        //dataPtr[0] = 255;
                        //dataPtr[1] = 0;
                        //dataPtr[2] = 0;
                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }
                    //dataPtr += nChan;
                    //dataPtrBorder += nChan;

                    //processar pixel (0,N)
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan + widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan + widthStep)[2];

                    if (Math.Round(blueSum / 9.0) > 255)
                        dataPtr[0] = 255;
                    else
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    if (Math.Round(greenSum / 9.0) > 255)
                        dataPtr[1] = 255;
                    else
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    if (Math.Round(redSum / 9.0) > 255)
                        dataPtr[2] = 255;
                    else
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                    //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    //dataPtr[0] = 255;
                    //dataPtr[1] = 0;
                    //dataPtr[2] = 0;
                    dataPtrBorder += widthStep;
                    dataPtr += widthStep;

                    //processar border direita
                    for (y = 1; y < height - 1; y++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - widthStep)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan)[0] + (dataPtrBorder - nChan + widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan)[1] + (dataPtrBorder - nChan + widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan)[2] + (dataPtrBorder - nChan + widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];

                        if (Math.Round(blueSum / 9.0) > 255)
                            dataPtr[0] = 255;
                        else
                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        if (Math.Round(greenSum / 9.0) > 255)
                            dataPtr[1] = 255;
                        else
                            dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        if (Math.Round(redSum / 9.0) > 255)
                            dataPtr[2] = 255;
                        else
                            dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                        //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        //dataPtr[0] = 255;
                        //dataPtr[1] = 0;
                        //dataPtr[2] = 0;
                        dataPtrBorder += widthStep;
                        dataPtr += widthStep;
                    }

                    //processar pixel (N,N)
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder - widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder - widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder - widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];

                    if (Math.Round(blueSum / 9.0) > 255)
                        dataPtr[0] = 255;
                    else
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    if (Math.Round(greenSum / 9.0) > 255)
                        dataPtr[1] = 255;
                    else
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    if (Math.Round(redSum / 9.0) > 255)
                        dataPtr[2] = 255;
                    else
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                    //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    //dataPtr[0] = 255;
                    //dataPtr[1] = 0;
                    //dataPtr[2] = 0;
                    dataPtr -= nChan;
                    dataPtrBorder -= nChan;

                    //processar border inferior
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder + nChan)[0] + (dataPtrBorder - widthStep)[0] + (dataPtrBorder + nChan - widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder + nChan)[1] + (dataPtrBorder - widthStep)[1] + (dataPtrBorder + nChan - widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder + nChan)[2] + (dataPtrBorder - widthStep)[2] + (dataPtrBorder + nChan - widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];

                        if (Math.Round(blueSum / 9.0) > 255)
                            dataPtr[0] = 255;
                        else
                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        if (Math.Round(greenSum / 9.0) > 255)
                            dataPtr[1] = 255;
                        else
                            dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        if (Math.Round(redSum / 9.0) > 255)
                            dataPtr[2] = 255;
                        else
                            dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                        //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        //dataPtr[0] = 255;
                        //dataPtr[1] = 0;
                        //dataPtr[2] = 0;
                        dataPtr -= nChan;
                        dataPtrBorder -= nChan;
                    }

                    //processar pixel (N,0)
                    //dataPtr -= nChan;
                    //dataPtrBorder -= nChan;
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder + nChan)[0] + 2 * (dataPtrBorder - widthStep)[0] + (dataPtrBorder + nChan - widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder + nChan)[1] + 2 * (dataPtrBorder - widthStep)[1] + (dataPtrBorder + nChan - widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder + nChan)[2] + 2 * (dataPtrBorder - widthStep)[2] + (dataPtrBorder + nChan - widthStep)[2];

                    if (Math.Round(blueSum / 9.0) > 255)
                        dataPtr[0] = 255;
                    else
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    if (Math.Round(greenSum / 9.0) > 255)
                        dataPtr[1] = 255;
                    else
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    if (Math.Round(redSum / 9.0) > 255)
                        dataPtr[2] = 255;
                    else
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                    //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    //dataPtr[0] = 255;
                    //dataPtr[1] = 0;
                    //dataPtr[2] = 0;
                    dataPtrBorder -= widthStep;
                    dataPtr -= widthStep;

                    //processar border esquerda
                    for (y = 1; y < height - 1; y++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - widthStep)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder + nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder + nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder + nChan - widthStep)[2];

                        if (Math.Round(blueSum / 9.0) > 255)
                            dataPtr[0] = 255;
                        else
                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        if (Math.Round(greenSum / 9.0) > 255)
                            dataPtr[1] = 255;
                        else
                            dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        if (Math.Round(redSum / 9.0) > 255)
                            dataPtr[2] = 255;
                        else
                            dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                        //dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        //dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        //dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        //dataPtr[0] = 255;
                        //dataPtr[1] = 0;
                        //dataPtr[2] = 0;
                        dataPtrBorder -= widthStep;
                        dataPtr -= widthStep;
                    }

                    //Image<Bgr, byte> aux = img.SmoothBlur(3, 3);

                    //for (int yd = 0; yd < height; yd++)
                    //{
                    //    for (int xd = 0; xd < width; xd++)
                    //    {
                    //        if (aux.Data[yd, xd, 0] != img.Data[yd, xd, 0] ||
                    //            aux.Data[yd, xd, 1] != img.Data[yd, xd, 1]||
                    //                aux.Data[yd, xd, 2] != img.Data[yd, xd, 2])
                    //                {
                    //            int i = 0;
                    //        }

                    //        // avança apontador 
                    //    }

                    //    //no fim da linha avança alinhamento
                    //}
                }

            }
        }
        /// <summary>
        /// Histogram equalization
        /// </summary>
        /// <param name="img"></param>
        /// 

        public static void NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight, float offset)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* resetPtr = dataPtr;
                byte* dataPtrBorder = dataPtr;
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Pointer to the image
                byte* resetPtrCopy = dataPtrCopy;


                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                float blueSum = 0, greenSum = 0, redSum = 0;
                int nC = m.nChannels;

                dataPtrCopy += nChan + widthStep;
                dataPtr += nChan + widthStep;
                if (nC == 3)
                {
                    for (y = 1; y < height - 1; y++)
                    {
                        for (x = 1; x < width - 1; x++)
                        {
                            //segunda linha
                            blueSum = matrix[1, 1] * (float)dataPtrCopy[0] +
                                +matrix[1, 0] * (float)(dataPtrCopy - nChan)[0] +
                                +matrix[1, 2] * (float)(dataPtrCopy + nChan)[0];

                            greenSum = matrix[1, 1] * (float)dataPtrCopy[1] +
                                +matrix[1, 0] * (dataPtrCopy - nChan)[1] +
                                +matrix[1, 2] * (dataPtrCopy + nChan)[1];

                            redSum = matrix[1, 1] * dataPtrCopy[2] +
                                +matrix[1, 0] * (dataPtrCopy - nChan)[2] +
                                +matrix[1, 2] * (dataPtrCopy + nChan)[2];


                            //primeira linha                    
                            blueSum += matrix[0, 1] * (dataPtrCopy - widthStep)[0] +
                                +matrix[0, 0] * (dataPtrCopy - widthStep - nChan)[0] +
                                +matrix[0, 2] * (dataPtrCopy - widthStep + nChan)[0];

                            greenSum += matrix[0, 1] * (dataPtrCopy - widthStep)[1] +
                                 +matrix[0, 0] * (dataPtrCopy - widthStep - nChan)[1] +
                                 +matrix[0, 2] * (dataPtrCopy - widthStep + nChan)[1];
                            redSum += matrix[0, 1] * (dataPtrCopy - widthStep)[2] +
                                +matrix[0, 0] * (dataPtrCopy - widthStep - nChan)[2] +
                                +matrix[0, 2] * (dataPtrCopy - widthStep + nChan)[2];


                            //terceira linha
                            blueSum += matrix[2, 1] * (dataPtrCopy + widthStep)[0] +
                                +matrix[2, 0] * (dataPtrCopy + widthStep - nChan)[0] +
                                +matrix[2, 2] * (dataPtrCopy + widthStep + nChan)[0];

                            greenSum += matrix[2, 1] * (dataPtrCopy + widthStep)[1] +
                                +matrix[2, 0] * (dataPtrCopy + widthStep - nChan)[1] +
                                +matrix[2, 2] * (dataPtrCopy + widthStep + nChan)[1];

                            redSum += matrix[2, 1] * (dataPtrCopy + widthStep)[2] +
                                +matrix[2, 0] * (dataPtrCopy + widthStep - nChan)[2] +
                                +matrix[2, 2] * (dataPtrCopy + widthStep + nChan)[2];


                            blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                            greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                            redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                            if (blueSum > 255)
                                dataPtr[0] = 255;
                            else if (blueSum < 0)
                                dataPtr[0] = (byte)0;
                            else dataPtr[0] = (byte)blueSum;
                            if (greenSum > 255)
                                dataPtr[1] = 255;
                            else if (greenSum < 0)
                                dataPtr[1] = (byte)0;
                            else dataPtr[1] = (byte)greenSum;
                            if (redSum > 255)
                                dataPtr[2] = 255;
                            else if (redSum < 0)
                                dataPtr[2] = (byte)0;
                            else dataPtr[2] = (byte)redSum;





                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }
                    //Console.WriteLine(matrix[0, 0]);

                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    dataPtrBorder = resetPtrCopy;

                    blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * dataPtrBorder[0] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[0, 1] * (dataPtrBorder)[0] +
                                    +matrix[0, 0] * (dataPtrBorder)[0] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[0];

                    greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * dataPtrBorder[1] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[0, 1] * (dataPtrBorder)[1] +
                                    +matrix[0, 0] * (dataPtrBorder)[1] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[1];

                    redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * dataPtrBorder[2] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[0, 1] * (dataPtrBorder)[2] +
                                    +matrix[0, 0] * (dataPtrBorder)[2] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[2];

                    blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                    greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                    redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                    dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                    dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                    dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[0, 1] * (dataPtrBorder)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[0];

                        greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[0, 1] * (dataPtrBorder)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[1];

                        redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[0, 1] * (dataPtrBorder)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[0, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[2];

                        blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                        greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                        redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                        dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                        dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                        dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar pixel (0,N)
                    blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[1, 2] * (dataPtrBorder)[0] +
                                    +matrix[0, 1] * (dataPtrBorder)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[0, 2] * (dataPtrBorder)[0] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[0];

                    greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[1, 2] * (dataPtrBorder)[1] +
                                    +matrix[0, 1] * (dataPtrBorder)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[0, 2] * (dataPtrBorder)[1] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[1];

                    redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[1, 2] * (dataPtrBorder)[2] +
                                    +matrix[0, 1] * (dataPtrBorder)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[0, 2] * (dataPtrBorder)[2] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[2];

                    blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                    greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                    redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                    dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                    dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                    dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                    dataPtrBorder += padding + nChan;
                    dataPtr += padding + nChan;

                    //processar border esqueda e direita
                    for (y = 1; y < height - 1; y++)
                    {
                        blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder)[0] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[0] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[0];

                        greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder)[1] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[1] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[1];

                        redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder)[2] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[2] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep + nChan)[2];

                        blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                        greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                        redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                        dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                        dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                        dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                        dataPtrBorder += widthStep - padding - nChan;
                        dataPtr += widthStep - padding - nChan;

                        blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[1, 2] * (dataPtrBorder)[0] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[0] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[0] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[0];

                        greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[1, 2] * (dataPtrBorder)[1] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[1] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[1] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[1];

                        redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[1, 2] * (dataPtrBorder)[2] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[2] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[2, 1] * (dataPtrBorder + widthStep)[2] +
                                    +matrix[2, 0] * (dataPtrBorder + widthStep - nChan)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + widthStep)[2];

                        blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                        greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                        redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                        dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                        dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                        dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                        dataPtrBorder += padding + nChan;
                        dataPtr += padding + nChan;
                    }

                    //processar o pixel (N,0)

                    blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder)[0] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[0] +
                                    +matrix[2, 1] * (dataPtrBorder)[0] +
                                    +matrix[2, 0] * (dataPtrBorder)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[0];

                    greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder)[1] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[1] +
                                    +matrix[2, 1] * (dataPtrBorder)[1] +
                                    +matrix[2, 0] * (dataPtrBorder)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[1];

                    redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder)[2] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[2] +
                                    +matrix[2, 1] * (dataPtrBorder)[2] +
                                    +matrix[2, 0] * (dataPtrBorder)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[2];

                    blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                    greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                    redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                    dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                    dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                    dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                    //processar a border inferior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[0] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[0] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[0] +
                                    +matrix[2, 1] * (dataPtrBorder)[0] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[0];

                        greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[1] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[1] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[1] +
                                    +matrix[2, 1] * (dataPtrBorder)[1] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[1];


                        redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[1, 2] * (dataPtrBorder + nChan)[2] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[2] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep + nChan)[2] +
                                    +matrix[2, 1] * (dataPtrBorder)[2] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[2, 2] * (dataPtrBorder + nChan)[2];


                        blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                        greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                        redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                        dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                        dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                        dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar o pixel (N,N)
                    blueSum = matrix[1, 1] * dataPtrBorder[0] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[1, 2] * (dataPtrBorder)[0] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[0] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[0] +
                                    +matrix[2, 1] * (dataPtrBorder)[0] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[0] +
                                    +matrix[2, 2] * (dataPtrBorder)[0];

                    greenSum = matrix[1, 1] * dataPtrBorder[1] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[1, 2] * (dataPtrBorder)[1] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[1] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[1] +
                                    +matrix[2, 1] * (dataPtrBorder)[1] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[1] +
                                    +matrix[2, 2] * (dataPtrBorder)[1];


                    redSum = matrix[1, 1] * dataPtrBorder[2] +
                                    +matrix[1, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[1, 2] * (dataPtrBorder)[2] +
                                    +matrix[0, 1] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[0, 0] * (dataPtrBorder - widthStep - nChan)[2] +
                                    +matrix[0, 2] * (dataPtrBorder - widthStep)[2] +
                                    +matrix[2, 1] * (dataPtrBorder)[2] +
                                    +matrix[2, 0] * (dataPtrBorder - nChan)[2] +
                                    +matrix[2, 2] * (dataPtrBorder)[2];


                    blueSum = (float)Math.Round((blueSum / matrixWeight) + offset);
                    greenSum = (float)Math.Round((greenSum / matrixWeight) + offset);
                    redSum = (float)Math.Round((redSum / matrixWeight) + offset);

                    dataPtr[0] = (byte)(blueSum < 0 ? 0 : blueSum > 255 ? 255 : blueSum);
                    dataPtr[1] = (byte)(greenSum < 0 ? 0 : greenSum > 255 ? 255 : greenSum);
                    dataPtr[2] = (byte)(redSum < 0 ? 0 : redSum > 255 ? 255 : redSum);
                }
            }
        }

        public static void Sobel(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* resetPtr = dataPtr;
                byte* dataPtrBorder = dataPtr;
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Pointer to the image
                byte* resetPtrCopy = dataPtrCopy;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int SxBlueSum = 0, SxGreenSum = 0, SxRedSum = 0, SyBlueSum = 0, SyGreenSum = 0, SyRedSum = 0, SBlue, SGreen, SRed = 0;
                int nC = m.nChannels;

                dataPtrCopy += nChan + widthStep;
                dataPtr += nChan + widthStep;
                if (nC == 3)
                {
                    for (y = 1; y < height - 1; y++)
                    {
                        for (x = 1; x < width - 1; x++)
                        {

                            SxBlueSum = (dataPtrCopy - widthStep - nChan)[0] + 2 * (dataPtrCopy - nChan)[0] + (dataPtrCopy + widthStep - nChan)[0] -
                                        (dataPtrCopy - widthStep + nChan)[0] - 2 * (dataPtrCopy + nChan)[0] - (dataPtrCopy + widthStep + nChan)[0];

                            SxGreenSum = (dataPtrCopy - widthStep - nChan)[1] + 2 * (dataPtrCopy - nChan)[1] + (dataPtrCopy + widthStep - nChan)[1] -
                                        (dataPtrCopy - widthStep + nChan)[1] - 2 * (dataPtrCopy + nChan)[1] - (dataPtrCopy + widthStep + nChan)[1];

                            SxRedSum = (dataPtrCopy - widthStep - nChan)[2] + 2 * (dataPtrCopy - nChan)[2] + (dataPtrCopy + widthStep - nChan)[2] -
                                        (dataPtrCopy - widthStep + nChan)[2] - 2 * (dataPtrCopy + nChan)[2] - (dataPtrCopy + widthStep + nChan)[2];


                            SyBlueSum = (dataPtrCopy + widthStep - nChan)[0] + 2 * (dataPtrCopy + widthStep)[0] + (dataPtrCopy + widthStep + nChan)[0] -
                                        (dataPtrCopy - widthStep - nChan)[0] - 2 * (dataPtrCopy - widthStep)[0] - (dataPtrCopy - widthStep + nChan)[0];

                            SyGreenSum = (dataPtrCopy + widthStep - nChan)[1] + 2 * (dataPtrCopy + widthStep)[1] + (dataPtrCopy + widthStep + nChan)[1] -
                                        (dataPtrCopy - widthStep - nChan)[1] - 2 * (dataPtrCopy - widthStep)[1] - (dataPtrCopy - widthStep + nChan)[1];

                            SyRedSum = (dataPtrCopy + widthStep - nChan)[2] + 2 * (dataPtrCopy + widthStep)[2] + (dataPtrCopy + widthStep + nChan)[2] -
                                        (dataPtrCopy - widthStep - nChan)[2] - 2 * (dataPtrCopy - widthStep)[2] - (dataPtrCopy - widthStep + nChan)[2];

                            SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                            SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                            SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                            if (SBlue > 255)
                                SBlue = 255;
                            else if (SBlue < 0)
                                SBlue = 0;

                            if (SGreen > 255)
                                SGreen = 255;
                            else if (SGreen < 0)
                                SGreen = 0;

                            if (SRed > 255)
                                SRed = 255;
                            else if (SRed < 0)
                                SRed = 0;



                            dataPtr[0] = (byte)SBlue;
                            dataPtr[1] = (byte)SGreen;
                            dataPtr[2] = (byte)SRed;

                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }

                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    dataPtrBorder = resetPtrCopy;

                    SxBlueSum = (dataPtrBorder)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder + widthStep)[0] -
                                        (dataPtrBorder + nChan)[0] - 2 * (dataPtrBorder + nChan)[0] - (dataPtrBorder + widthStep + nChan)[0];

                    SxGreenSum = (dataPtrBorder)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder + widthStep)[1] -
                                        (dataPtrBorder + nChan)[1] - 2 * (dataPtrBorder + nChan)[1] - (dataPtrBorder + widthStep + nChan)[1];

                    SxRedSum = (dataPtrBorder)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder + widthStep)[2] -
                                        (dataPtrBorder + nChan)[2] - 2 * (dataPtrBorder + nChan)[2] - (dataPtrBorder + widthStep + nChan)[2];


                    SyBlueSum = (dataPtrBorder + widthStep)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + widthStep + nChan)[0] -
                                (dataPtrBorder)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder + nChan)[0];

                    SyGreenSum = (dataPtrBorder + widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + widthStep + nChan)[1] -
                                (dataPtrBorder)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder + nChan)[1];

                    SyRedSum = (dataPtrBorder + widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + widthStep + nChan)[2] -
                                (dataPtrBorder)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder + nChan)[2];

                    SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                    SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                    SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                    dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                    dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                    dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        SxBlueSum = (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder - nChan)[0] + (dataPtrBorder + widthStep - nChan)[0] -
                                        (dataPtrBorder + nChan)[0] - 2 * (dataPtrBorder + nChan)[0] - (dataPtrBorder + widthStep + nChan)[0];

                        SxGreenSum = (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder - nChan)[1] + (dataPtrBorder + widthStep - nChan)[1] -
                                        (dataPtrBorder + nChan)[1] - 2 * (dataPtrBorder + nChan)[1] - (dataPtrBorder + widthStep + nChan)[1];

                        SxRedSum = (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder - nChan)[2] + (dataPtrBorder + widthStep - nChan)[2] -
                                        (dataPtrBorder + nChan)[2] - 2 * (dataPtrBorder + nChan)[2] - (dataPtrBorder + widthStep + nChan)[2];


                        SyBlueSum = (dataPtrBorder + widthStep - nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + widthStep + nChan)[0] -
                                    (dataPtrBorder - nChan)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder + nChan)[0];

                        SyGreenSum = (dataPtrBorder + widthStep - nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + widthStep + nChan)[1] -
                                    (dataPtrBorder - nChan)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder + nChan)[1];

                        SyRedSum = (dataPtrBorder + widthStep - nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + widthStep + nChan)[2] -
                                    (dataPtrBorder - nChan)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder + nChan)[2];

                        SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                        SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                        SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                        dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                        dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                        dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar pixel (0,N)
                    SxBlueSum = (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder - nChan)[0] + (dataPtrBorder + widthStep - nChan)[0] -
                                        (dataPtrBorder)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder + widthStep)[0];

                    SxGreenSum = (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder - nChan)[1] + (dataPtrBorder + widthStep - nChan)[1] -
                                        (dataPtrBorder)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder + widthStep)[1];

                    SxRedSum = (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder - nChan)[2] + (dataPtrBorder + widthStep - nChan)[2] -
                                        (dataPtrBorder)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder + widthStep)[2];


                    SyBlueSum = (dataPtrBorder + widthStep - nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + widthStep)[0] -
                                (dataPtrBorder - nChan)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder)[0];

                    SyGreenSum = (dataPtrBorder + widthStep - nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + widthStep)[1] -
                                (dataPtrBorder - nChan)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder)[1];

                    SyRedSum = (dataPtrBorder + widthStep - nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + widthStep)[2] -
                                (dataPtrBorder - nChan)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder)[2];

                    SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                    SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                    SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                    dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                    dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                    dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                    dataPtrBorder += padding + nChan;
                    dataPtr += padding + nChan;

                    //processar border esquerda e direita
                    for (y = 1; y < height - 1; y++)
                    {
                        SxBlueSum = (dataPtrBorder - widthStep)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder + widthStep)[0] -
                                        (dataPtrBorder - widthStep + nChan)[0] - 2 * (dataPtrBorder + nChan)[0] - (dataPtrBorder + widthStep + nChan)[0];

                        SxGreenSum = (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder + widthStep)[1] -
                                        (dataPtrBorder - widthStep + nChan)[1] - 2 * (dataPtrBorder + nChan)[1] - (dataPtrBorder + widthStep + nChan)[1];

                        SxRedSum = (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder + widthStep)[2] -
                                        (dataPtrBorder - widthStep + nChan)[2] - 2 * (dataPtrBorder + nChan)[2] - (dataPtrBorder + widthStep + nChan)[2];


                        SyBlueSum = (dataPtrBorder + widthStep)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + widthStep + nChan)[0] -
                                    (dataPtrBorder - widthStep)[0] - 2 * (dataPtrBorder - widthStep)[0] - (dataPtrBorder - widthStep + nChan)[0];

                        SyGreenSum = (dataPtrBorder + widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + widthStep + nChan)[1] -
                                    (dataPtrBorder - widthStep)[1] - 2 * (dataPtrBorder - widthStep)[1] - (dataPtrBorder - widthStep + nChan)[1];

                        SyRedSum = (dataPtrBorder + widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + widthStep + nChan)[2] -
                                    (dataPtrBorder - widthStep)[2] - 2 * (dataPtrBorder - widthStep)[2] - (dataPtrBorder - widthStep + nChan)[2];

                        SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                        SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                        SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                        dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                        dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                        dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                        dataPtrBorder += widthStep - padding - nChan;
                        dataPtr += widthStep - padding - nChan;

                        SxBlueSum = (dataPtrBorder - widthStep - nChan)[0] + 2 * (dataPtrBorder - nChan)[0] + (dataPtrBorder + widthStep - nChan)[0] -
                                        (dataPtrBorder - widthStep)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder + widthStep)[0];

                        SxGreenSum = (dataPtrBorder - widthStep - nChan)[1] + 2 * (dataPtrBorder - nChan)[1] + (dataPtrBorder + widthStep - nChan)[1] -
                                        (dataPtrBorder - widthStep)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder + widthStep)[1];

                        SxRedSum = (dataPtrBorder - widthStep - nChan)[2] + 2 * (dataPtrBorder - nChan)[2] + (dataPtrBorder + widthStep - nChan)[2] -
                                        (dataPtrBorder - widthStep)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder + widthStep)[2];


                        SyBlueSum = (dataPtrBorder + widthStep - nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + widthStep)[0] -
                                    (dataPtrBorder - widthStep - nChan)[0] - 2 * (dataPtrBorder - widthStep)[0] - (dataPtrBorder - widthStep)[0];

                        SyGreenSum = (dataPtrBorder + widthStep - nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + widthStep)[1] -
                                    (dataPtrBorder - widthStep - nChan)[1] - 2 * (dataPtrBorder - widthStep)[1] - (dataPtrBorder - widthStep)[1];

                        SyRedSum = (dataPtrBorder + widthStep - nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + widthStep)[2] -
                                    (dataPtrBorder - widthStep - nChan)[2] - 2 * (dataPtrBorder - widthStep)[2] - (dataPtrBorder - widthStep)[2];

                        SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                        SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                        SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                        dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                        dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                        dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                        dataPtrBorder += padding + nChan;
                        dataPtr += padding + nChan;
                    }

                    //processar o pixel (N,0)

                    SxBlueSum = (dataPtrBorder - widthStep)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder)[0] -
                                        (dataPtrBorder - widthStep + nChan)[0] - 2 * (dataPtrBorder + nChan)[0] - (dataPtrBorder + nChan)[0];

                    SxGreenSum = (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder)[1] -
                                        (dataPtrBorder - widthStep + nChan)[1] - 2 * (dataPtrBorder + nChan)[1] - (dataPtrBorder + nChan)[1];

                    SxRedSum = (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder)[2] -
                                        (dataPtrBorder - widthStep + nChan)[2] - 2 * (dataPtrBorder + nChan)[2] - (dataPtrBorder + nChan)[2];


                    SyBlueSum = (dataPtrBorder)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder + nChan)[0] -
                                (dataPtrBorder - widthStep)[0] - 2 * (dataPtrBorder - widthStep)[0] - (dataPtrBorder - widthStep + nChan)[0];

                    SyGreenSum = (dataPtrBorder)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder + nChan)[1] -
                                (dataPtrBorder - widthStep)[1] - 2 * (dataPtrBorder - widthStep)[1] - (dataPtrBorder - widthStep + nChan)[1];

                    SyRedSum = (dataPtrBorder)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder + nChan)[2] -
                                (dataPtrBorder - widthStep)[2] - 2 * (dataPtrBorder - widthStep)[2] - (dataPtrBorder - widthStep + nChan)[2];

                    SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                    SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                    SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                    dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                    dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                    dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                    //processar a border inferior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;

                    for (x = 1; x < width - 1; x++)
                    {
                        SxBlueSum = (dataPtrBorder - widthStep - nChan)[0] + 2 * (dataPtrBorder - nChan)[0] + (dataPtrBorder - nChan)[0] -
                                        (dataPtrBorder - widthStep + nChan)[0] - 2 * (dataPtrBorder + nChan)[0] - (dataPtrBorder + nChan)[0];

                        SxGreenSum = (dataPtrBorder - widthStep - nChan)[1] + 2 * (dataPtrBorder - nChan)[1] + (dataPtrBorder - nChan)[1] -
                                        (dataPtrBorder - widthStep + nChan)[1] - 2 * (dataPtrBorder + nChan)[1] - (dataPtrBorder + nChan)[1];

                        SxRedSum = (dataPtrBorder - widthStep - nChan)[2] + 2 * (dataPtrBorder - nChan)[2] + (dataPtrBorder - nChan)[2] -
                                        (dataPtrBorder - widthStep + nChan)[2] - 2 * (dataPtrBorder + nChan)[2] - (dataPtrBorder + nChan)[2];


                        SyBlueSum = (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder + nChan)[0] -
                                    (dataPtrBorder - widthStep - nChan)[0] - 2 * (dataPtrBorder - widthStep)[0] - (dataPtrBorder - widthStep + nChan)[0];

                        SyGreenSum = (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder + nChan)[1] -
                                    (dataPtrBorder - widthStep - nChan)[1] - 2 * (dataPtrBorder - widthStep)[1] - (dataPtrBorder - widthStep + nChan)[1];

                        SyRedSum = (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder + nChan)[2] -
                                    (dataPtrBorder - widthStep - nChan)[2] - 2 * (dataPtrBorder - widthStep)[2] - (dataPtrBorder - widthStep + nChan)[2];

                        SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                        SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                        SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                        dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                        dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                        dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar o pixel (N,N)
                    SxBlueSum = (dataPtrBorder - widthStep - nChan)[0] + 2 * (dataPtrBorder - nChan)[0] + (dataPtrBorder - nChan)[0] -
                                        (dataPtrBorder - widthStep)[0] - 2 * (dataPtrBorder)[0] - (dataPtrBorder)[0];

                    SxGreenSum = (dataPtrBorder - widthStep - nChan)[1] + 2 * (dataPtrBorder - nChan)[1] + (dataPtrBorder - nChan)[1] -
                                        (dataPtrBorder - widthStep)[1] - 2 * (dataPtrBorder)[1] - (dataPtrBorder)[1];

                    SxRedSum = (dataPtrBorder - widthStep - nChan)[2] + 2 * (dataPtrBorder - nChan)[2] + (dataPtrBorder - nChan)[2] -
                                        (dataPtrBorder - widthStep)[2] - 2 * (dataPtrBorder)[2] - (dataPtrBorder)[2];


                    SyBlueSum = (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder)[0] + (dataPtrBorder)[0] -
                                (dataPtrBorder - widthStep - nChan)[0] - 2 * (dataPtrBorder - widthStep)[0] - (dataPtrBorder - widthStep)[0];

                    SyGreenSum = (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder)[1] + (dataPtrBorder)[1] -
                                (dataPtrBorder - widthStep - nChan)[1] - 2 * (dataPtrBorder - widthStep)[1] - (dataPtrBorder - widthStep)[1];

                    SyRedSum = (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder)[2] + (dataPtrBorder)[2] -
                                (dataPtrBorder - widthStep - nChan)[2] - 2 * (dataPtrBorder - widthStep)[2] - (dataPtrBorder - widthStep)[2];

                    SBlue = Math.Abs(SxBlueSum) + Math.Abs(SyBlueSum);
                    SGreen = Math.Abs(SxGreenSum) + Math.Abs(SyGreenSum);
                    SRed = Math.Abs(SxRedSum) + Math.Abs(SyRedSum);

                    dataPtr[0] = (byte)(SBlue < 0 ? 0 : SBlue > 255 ? 255 : SBlue);
                    dataPtr[1] = (byte)(SGreen < 0 ? 0 : SGreen > 255 ? 255 : SGreen);
                    dataPtr[2] = (byte)(SRed < 0 ? 0 : SRed > 255 ? 255 : SRed);
                }
            }
        }

        public static void Diferentiation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* resetPtr = dataPtr;
                byte* dataPtrBorder = dataPtr;
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Pointer to the image
                byte* resetPtrCopy = dataPtrCopy;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int GBlue = 0, GGreen = 0, GRed = 0;
                int nC = m.nChannels;

                //dataPtrCopy += nChan + widthStep;
                //dataPtr += nChan + widthStep;
                if (nC == 3)
                {
                    for (y = 0; y < height - 1; y++)
                    {
                        for (x = 0; x < width - 1; x++)
                        {
                            GBlue = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan)[0]) + Math.Abs(dataPtrCopy[0] - (dataPtrCopy + widthStep)[0]);
                            GGreen = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan)[1]) + Math.Abs(dataPtrCopy[1] - (dataPtrCopy + widthStep)[1]);
                            GRed = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan)[2]) + Math.Abs(dataPtrCopy[2] - (dataPtrCopy + widthStep)[2]);

                            if (GBlue > 255)
                                GBlue = 255;
                            else if (GBlue < 0)
                                GBlue = 0;

                            if (GGreen > 255)
                                GGreen = 255;
                            else if (GGreen < 0)
                                GGreen = 0;

                            if (GRed > 255)
                                GRed = 255;
                            else if (GRed < 0)
                                GRed = 0;

                            dataPtr[0] = (byte)GBlue;
                            dataPtr[1] = (byte)GGreen;
                            dataPtr[2] = (byte)GRed;
                            dataPtr += nChan;
                            dataPtrCopy += nChan;
                        }
                        dataPtrCopy += padding + nChan;
                        dataPtr += padding + nChan;
                    }

                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    dataPtrBorder = resetPtrCopy;

                    GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + nChan)[0]) + Math.Abs(dataPtrBorder[0] - (dataPtrBorder + widthStep)[0]);
                    GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + nChan)[1]) + Math.Abs(dataPtrBorder[1] - (dataPtrBorder + widthStep)[1]);
                    GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + nChan)[2]) + Math.Abs(dataPtrBorder[2] - (dataPtrBorder + widthStep)[2]);

                    dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                    dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                    dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + nChan)[0]) + Math.Abs(dataPtrBorder[0] - (dataPtrBorder + widthStep)[0]);
                        GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + nChan)[1]) + Math.Abs(dataPtrBorder[1] - (dataPtrBorder + widthStep)[1]);
                        GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + nChan)[2]) + Math.Abs(dataPtrBorder[2] - (dataPtrBorder + widthStep)[2]);

                        dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                        dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                        dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar pixel (0,N)
                    //subraçai de um pelo ele mesmo da 0
                    GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + widthStep)[0]);
                    GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + widthStep)[1]);
                    GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + widthStep)[2]);


                    dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                    dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                    dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                    dataPtrBorder += padding + nChan;
                    dataPtr += padding + nChan;

                    //processar border esqueda e direita
                    for (y = 1; y < height - 1; y++)
                    {
                        GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + nChan)[0]) + Math.Abs(dataPtrBorder[0] - (dataPtrBorder + widthStep)[0]);
                        GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + nChan)[1]) + Math.Abs(dataPtrBorder[1] - (dataPtrBorder + widthStep)[1]);
                        GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + nChan)[2]) + Math.Abs(dataPtrBorder[2] - (dataPtrBorder + widthStep)[2]);

                        dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                        dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                        dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                        dataPtrBorder += widthStep - padding - nChan;
                        dataPtr += widthStep - padding - nChan;

                        GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + widthStep)[0]);
                        GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + widthStep)[1]);
                        GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + widthStep)[2]);

                        dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                        dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                        dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                        dataPtrBorder += padding + nChan;
                        dataPtr += padding + nChan;
                    }

                    //processar o pixel (N,0)
                    GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + nChan)[0]);
                    GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + nChan)[1]);
                    GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + nChan)[2]);

                    dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                    dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                    dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                    //processar a border inferior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1; x++)
                    {
                        GBlue = Math.Abs(dataPtrBorder[0] - (dataPtrBorder + nChan)[0]);
                        GGreen = Math.Abs(dataPtrBorder[1] - (dataPtrBorder + nChan)[1]);
                        GRed = Math.Abs(dataPtrBorder[2] - (dataPtrBorder + nChan)[2]);

                        dataPtr[0] = (byte)(GBlue < 0 ? 0 : GBlue > 255 ? 255 : GBlue);
                        dataPtr[1] = (byte)(GGreen < 0 ? 0 : GGreen > 255 ? 255 : GGreen);
                        dataPtr[2] = (byte)(GRed < 0 ? 0 : GRed > 255 ? 255 : GRed);

                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

                    //processar o pixel (N,N)s
                    dataPtr[0] = 0;
                    dataPtr[1] = 0;
                    dataPtr[2] = 0;
                }
            }
        }
        public static void Equalization(Image<Bgr, byte> img)
        {
            unsafe
            {
                Image<Ycc, byte> imgYCC = img.Convert<Ycc, byte>();

                int[] hist = new int[256];
                // acesso directo à memoria da imagem (sequencial)
                // top left to bottom right
                MIplImage m = imgYCC.MIplImage;
                byte* dataPtr = (Byte*)m.imageData.ToPointer();

                int h = img.Height;
                int w = img.Width;
                int nC = m.nChannels;
                int lineStep = m.widthStep - m.nChannels * m.width;
                int x, y;
                // get Y component histogram
                for (y = 0; y < h; y++)
                {
                    for (x = 0; x < w; x++)
                    {
                        hist[(int)dataPtr[0]]++;
                        // avança apontador 
                        dataPtr += nC;
                    }
                    //no fim da linha avança alinhamento
                    dataPtr += lineStep;
                }


                //find new equalized intensities
                float[] newHist = new float[256];
                int acumHist = 0;
                float histMean = img.Width * img.Height / 256.0f;
                int acumHistMin = 0;
                for (int idx = 0; idx < 256; idx++)
                {
                    //get minimum acumulated value > 0
                    if (acumHist == 0)
                        acumHistMin = hist[idx];

                    acumHist += hist[idx];

                    newHist[idx] = (float)Math.Round((((double)acumHist - acumHistMin) / (img.Width * img.Height - acumHistMin)) * (256 - 1));

                }
                dataPtr = (Byte*)m.imageData.ToPointer();
                //apply equalization
                for (y = 0; y < h; y++)
                {
                    for (x = 0; x < w; x++)
                    {
                        dataPtr[0] = (byte)newHist[(int)dataPtr[0]]; //lookup table
                        // avança apontador 
                        dataPtr += nC;
                    }
                    //no fim da linha avança alinhamento
                    dataPtr += lineStep;
                }

                img.ConvertFrom<Ycc, byte>(imgYCC);
            }
        }

        public static int[] Histogram_Gray(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                byte blue, green, red, gray;
                int[] hist = new int[256];

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //retrive 3 colour components
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // convert to gray
                        gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                        //vai ao index do hist que neste caso (int)dataPtr[0] e o valor do pixel 0 a 255
                        hist[gray]++;
                        // avança apontador 
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento
                    dataPtr += padding;
                }

                return hist;
            }
        }

        public static int[,] Histogram_RGB(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                byte blue, green, red, gray;
                int[,] hist = new int[3, 256];

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //retrive 3 colour components
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        //vai ao index do hist que neste caso (int)dataPtr[0] e o valor do pixel 0 a 255
                        hist[0, blue]++;
                        hist[1, green]++;
                        hist[2, red]++;

                        // avança apontador 
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento
                    dataPtr += padding;
                }

                return hist;
            }
        }

        public static int[,] Histogram_All(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                byte blue, green, red, gray;
                int[,] hist = new int[4, 256];

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //retrive 3 colour components
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // convert to gray
                        gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                        //vai ao index do hist que neste caso (int)dataPtr[0] e o valor do pixel 0 a 255
                        hist[0, gray]++;
                        hist[1, blue]++;
                        hist[2, green]++;
                        hist[3, red]++;
                        // avança apontador 
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento
                    dataPtr += padding;
                }

                return hist;
            }
        }

        public static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* resetPtr = dataPtr;
                byte* dataPtrBorder = dataPtr;
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Pointer to the image
                byte* resetPtrCopy = dataPtrCopy;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y, i, j;
                int nC = m.nChannels;

                byte[] imgVecB = new byte[9];
                byte[] imgVecG = new byte[9];
                byte[] imgVecR = new byte[9];
                int index;
                double eucSum, min;
                dataPtrCopy += nChan + widthStep;
                dataPtr += nChan + widthStep;
                if (nC == 3)
                {

                    for (y = 1; y < height - 1; y++)
                    {
                        for (x = 1; x < width - 1; x++)
                        {
                            imgVecB[0] = (dataPtrCopy - widthStep - nChan)[0];
                            imgVecG[0] = (dataPtrCopy - widthStep - nChan)[1];
                            imgVecR[0] = (dataPtrCopy - widthStep - nChan)[2];

                            imgVecB[1] = (dataPtrCopy - widthStep)[0];
                            imgVecG[1] = (dataPtrCopy - widthStep)[1];
                            imgVecR[1] = (dataPtrCopy - widthStep)[2];

                            imgVecB[2] = (dataPtrCopy - widthStep + nChan)[0];
                            imgVecG[2] = (dataPtrCopy - widthStep + nChan)[1];
                            imgVecR[2] = (dataPtrCopy - widthStep + nChan)[2];

                            imgVecB[3] = (dataPtrCopy - nChan)[0];
                            imgVecG[3] = (dataPtrCopy - nChan)[1];
                            imgVecR[3] = (dataPtrCopy - nChan)[2];

                            imgVecB[4] = (dataPtrCopy)[0];
                            imgVecG[4] = (dataPtrCopy)[1];
                            imgVecR[4] = (dataPtrCopy)[2];

                            imgVecB[5] = (dataPtrCopy + nChan)[0];
                            imgVecG[5] = (dataPtrCopy + nChan)[1];
                            imgVecR[5] = (dataPtrCopy + nChan)[2];

                            imgVecB[6] = (dataPtrCopy + widthStep - nChan)[0];
                            imgVecG[6] = (dataPtrCopy + widthStep - nChan)[1];
                            imgVecR[6] = (dataPtrCopy + widthStep - nChan)[2];

                            imgVecB[7] = (dataPtrCopy + widthStep)[0];
                            imgVecG[7] = (dataPtrCopy + widthStep)[1];
                            imgVecR[7] = (dataPtrCopy + widthStep)[2];

                            imgVecB[8] = (dataPtrCopy + widthStep + nChan)[0];
                            imgVecG[8] = (dataPtrCopy + widthStep + nChan)[1];
                            imgVecR[8] = (dataPtrCopy + widthStep + nChan)[2];

                            min = 0;
                            index = 0;
                            for (i = 0; i < 9; i++)
                            {
                                eucSum = 0;
                                for (j = 0; j < 9; j++)
                                    eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                                //eucSum += Math.Sqrt(Math.Pow((imgVecB[i] - imgVecB[j]),2)  + Math.Pow((imgVecG[i] - imgVecG[j]),2) + Math.Pow((imgVecR[i] - imgVecR[j]),2));

                                if (i == 0)
                                    min = eucSum;

                                if (eucSum < min)
                                {
                                    min = eucSum;
                                    index = i;
                                }

                            }
                            dataPtr[0] = imgVecB[index];
                            dataPtr[1] = imgVecG[index];
                            dataPtr[2] = imgVecR[index];

                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }

                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    dataPtrCopy = resetPtrCopy;

                    imgVecB[0] = (dataPtrCopy)[0];
                    imgVecG[0] = (dataPtrCopy)[1];
                    imgVecR[0] = (dataPtrCopy)[2];

                    imgVecB[1] = (dataPtrCopy)[0];
                    imgVecG[1] = (dataPtrCopy)[1];
                    imgVecR[1] = (dataPtrCopy)[2];

                    imgVecB[2] = (dataPtrCopy + nChan)[0];
                    imgVecG[2] = (dataPtrCopy + nChan)[1];
                    imgVecR[2] = (dataPtrCopy + nChan)[2];

                    imgVecB[3] = (dataPtrCopy)[0];
                    imgVecG[3] = (dataPtrCopy)[1];
                    imgVecR[3] = (dataPtrCopy)[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy + nChan)[0];
                    imgVecG[5] = (dataPtrCopy + nChan)[1];
                    imgVecR[5] = (dataPtrCopy + nChan)[2];

                    imgVecB[6] = (dataPtrCopy + widthStep)[0];
                    imgVecG[6] = (dataPtrCopy + widthStep)[1];
                    imgVecR[6] = (dataPtrCopy + widthStep)[2];

                    imgVecB[7] = (dataPtrCopy + widthStep)[0];
                    imgVecG[7] = (dataPtrCopy + widthStep)[1];
                    imgVecR[7] = (dataPtrCopy + widthStep)[2];

                    imgVecB[8] = (dataPtrCopy + widthStep + nChan)[0];
                    imgVecG[8] = (dataPtrCopy + widthStep + nChan)[1];
                    imgVecR[8] = (dataPtrCopy + widthStep + nChan)[2];

                    min = 0;
                    index = 0;
                    for (i = 0; i < 9; i++)
                    {
                        eucSum = 0;
                        for (j = 0; j < 9; j++)
                            eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                        //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                        if (i == 0)
                            min = eucSum;

                        if (eucSum < min)
                        {
                            min = eucSum;
                            index = i;
                        }

                    }
                    dataPtr[0] = imgVecB[index];
                    dataPtr[1] = imgVecG[index];
                    dataPtr[2] = imgVecR[index];

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                    for (x = 1; x < width - 1; x++)
                    {


                        imgVecB[0] = (dataPtrCopy - nChan)[0];
                        imgVecG[0] = (dataPtrCopy - nChan)[1];
                        imgVecR[0] = (dataPtrCopy - nChan)[2];

                        imgVecB[1] = (dataPtrCopy)[0];
                        imgVecG[1] = (dataPtrCopy)[1];
                        imgVecR[1] = (dataPtrCopy)[2];

                        imgVecB[2] = (dataPtrCopy + nChan)[0];
                        imgVecG[2] = (dataPtrCopy + nChan)[1];
                        imgVecR[2] = (dataPtrCopy + nChan)[2];

                        imgVecB[3] = (dataPtrCopy - nChan)[0];
                        imgVecG[3] = (dataPtrCopy - nChan)[1];
                        imgVecR[3] = (dataPtrCopy - nChan)[2];

                        imgVecB[4] = (dataPtrCopy)[0];
                        imgVecG[4] = (dataPtrCopy)[1];
                        imgVecR[4] = (dataPtrCopy)[2];

                        imgVecB[5] = (dataPtrCopy + nChan)[0];
                        imgVecG[5] = (dataPtrCopy + nChan)[1];
                        imgVecR[5] = (dataPtrCopy + nChan)[2];

                        imgVecB[6] = (dataPtrCopy + widthStep - nChan)[0];
                        imgVecG[6] = (dataPtrCopy + widthStep - nChan)[1];
                        imgVecR[6] = (dataPtrCopy + widthStep - nChan)[2];

                        imgVecB[7] = (dataPtrCopy + widthStep)[0];
                        imgVecG[7] = (dataPtrCopy + widthStep)[1];
                        imgVecR[7] = (dataPtrCopy + widthStep)[2];

                        imgVecB[8] = (dataPtrCopy + widthStep + nChan)[0];
                        imgVecG[8] = (dataPtrCopy + widthStep + nChan)[1];
                        imgVecR[8] = (dataPtrCopy + widthStep + nChan)[2];

                        min = 0;
                        index = 0;
                        for (i = 0; i < 9; i++)
                        {
                            eucSum = 0;
                            for (j = 0; j < 9; j++)
                                eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                            //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                            if (i == 0)
                                min = eucSum;

                            if (eucSum < min)
                            {
                                min = eucSum;
                                index = i;
                            }

                        }
                        dataPtr[0] = imgVecB[index];
                        dataPtr[1] = imgVecG[index];
                        dataPtr[2] = imgVecR[index];

                        dataPtr += nChan;
                        dataPtrCopy += nChan;
                    }

                    //processar pixel (0,N)
                    imgVecB[0] = (dataPtrCopy - nChan)[0];
                    imgVecG[0] = (dataPtrCopy - nChan)[1];
                    imgVecR[0] = (dataPtrCopy - nChan)[2];

                    imgVecB[1] = (dataPtrCopy)[0];
                    imgVecG[1] = (dataPtrCopy)[1];
                    imgVecR[1] = (dataPtrCopy)[2];

                    imgVecB[2] = (dataPtrCopy)[0];
                    imgVecG[2] = (dataPtrCopy)[1];
                    imgVecR[2] = (dataPtrCopy)[2];

                    imgVecB[3] = (dataPtrCopy - nChan)[0];
                    imgVecG[3] = (dataPtrCopy - nChan)[1];
                    imgVecR[3] = (dataPtrCopy - nChan)[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy)[0];
                    imgVecG[5] = (dataPtrCopy)[1];
                    imgVecR[5] = (dataPtrCopy)[2];

                    imgVecB[6] = (dataPtrCopy + widthStep - nChan)[0];
                    imgVecG[6] = (dataPtrCopy + widthStep - nChan)[1];
                    imgVecR[6] = (dataPtrCopy + widthStep - nChan)[2];

                    imgVecB[7] = (dataPtrCopy + widthStep)[0];
                    imgVecG[7] = (dataPtrCopy + widthStep)[1];
                    imgVecR[7] = (dataPtrCopy + widthStep)[2];

                    imgVecB[8] = (dataPtrCopy + widthStep)[0];
                    imgVecG[8] = (dataPtrCopy + widthStep)[1];
                    imgVecR[8] = (dataPtrCopy + widthStep)[2];

                    min = 0;
                    index = 0;
                    for (i = 0; i < 9; i++)
                    {
                        eucSum = 0;
                        for (j = 0; j < 9; j++)
                            eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                        //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                        if (i == 0)
                            min = eucSum;

                        if (eucSum < min)
                        {
                            min = eucSum;
                            index = i;
                        }

                    }
                    dataPtr[0] = imgVecB[index];
                    dataPtr[1] = imgVecG[index];
                    dataPtr[2] = imgVecR[index];

                    dataPtrCopy += widthStep;
                    dataPtr += widthStep;

                    //processar border da direita
                    for (y = 1; y < height - 1; y++)
                    {
                        imgVecB[0] = (dataPtrCopy - nChan - widthStep)[0];
                        imgVecG[0] = (dataPtrCopy - nChan - widthStep)[1];
                        imgVecR[0] = (dataPtrCopy - nChan - widthStep)[2];

                        imgVecB[1] = (dataPtrCopy - widthStep)[0];
                        imgVecG[1] = (dataPtrCopy - widthStep)[1];
                        imgVecR[1] = (dataPtrCopy - widthStep)[2];

                        imgVecB[2] = (dataPtrCopy - widthStep)[0];
                        imgVecG[2] = (dataPtrCopy - widthStep)[1];
                        imgVecR[2] = (dataPtrCopy - widthStep)[2];

                        imgVecB[3] = (dataPtrCopy - nChan)[0];
                        imgVecG[3] = (dataPtrCopy - nChan)[1];
                        imgVecR[3] = (dataPtrCopy - nChan)[2];

                        imgVecB[4] = (dataPtrCopy)[0];
                        imgVecG[4] = (dataPtrCopy)[1];
                        imgVecR[4] = (dataPtrCopy)[2];

                        imgVecB[5] = (dataPtrCopy)[0];
                        imgVecG[5] = (dataPtrCopy)[1];
                        imgVecR[5] = (dataPtrCopy)[2];

                        imgVecB[6] = (dataPtrCopy + widthStep - nChan)[0];
                        imgVecG[6] = (dataPtrCopy + widthStep - nChan)[1];
                        imgVecR[6] = (dataPtrCopy + widthStep - nChan)[2];

                        imgVecB[7] = (dataPtrCopy + widthStep)[0];
                        imgVecG[7] = (dataPtrCopy + widthStep)[1];
                        imgVecR[7] = (dataPtrCopy + widthStep)[2];

                        imgVecB[8] = (dataPtrCopy + widthStep)[0];
                        imgVecG[8] = (dataPtrCopy + widthStep)[1];
                        imgVecR[8] = (dataPtrCopy + widthStep)[2];

                        min = 0;
                        index = 0;
                        for (i = 0; i < 9; i++)
                        {
                            eucSum = 0;
                            for (j = 0; j < 9; j++)
                                eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                            //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                            if (i == 0)
                                min = eucSum;

                            if (eucSum < min)
                            {
                                min = eucSum;
                                index = i;
                            }

                        }
                        dataPtr[0] = imgVecB[index];
                        dataPtr[1] = imgVecG[index];
                        dataPtr[2] = imgVecR[index];

                        dataPtrCopy += widthStep;
                        dataPtr += widthStep;
                    }

                    //processar (N,N)

                    imgVecB[0] = (dataPtrCopy - nChan - widthStep)[0];
                    imgVecG[0] = (dataPtrCopy - nChan - widthStep)[1];
                    imgVecR[0] = (dataPtrCopy - nChan - widthStep)[2];

                    imgVecB[1] = (dataPtrCopy - widthStep)[0];
                    imgVecG[1] = (dataPtrCopy - widthStep)[1];
                    imgVecR[1] = (dataPtrCopy - widthStep)[2];

                    imgVecB[2] = (dataPtrCopy - widthStep)[0];
                    imgVecG[2] = (dataPtrCopy - widthStep)[1];
                    imgVecR[2] = (dataPtrCopy - widthStep)[2];

                    imgVecB[3] = (dataPtrCopy - nChan)[0];
                    imgVecG[3] = (dataPtrCopy - nChan)[1];
                    imgVecR[3] = (dataPtrCopy - nChan)[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy)[0];
                    imgVecG[5] = (dataPtrCopy)[1];
                    imgVecR[5] = (dataPtrCopy)[2];

                    imgVecB[6] = (dataPtrCopy - nChan)[0];
                    imgVecG[6] = (dataPtrCopy - nChan)[1];
                    imgVecR[6] = (dataPtrCopy - nChan)[2];

                    imgVecB[7] = (dataPtrCopy)[0];
                    imgVecG[7] = (dataPtrCopy)[1];
                    imgVecR[7] = (dataPtrCopy)[2];

                    imgVecB[8] = (dataPtrCopy)[0];
                    imgVecG[8] = (dataPtrCopy)[1];
                    imgVecR[8] = (dataPtrCopy)[2];

                    min = 0;
                    index = 0;
                    for (i = 0; i < 9; i++)
                    {
                        eucSum = 0;
                        for (j = 0; j < 9; j++)
                            eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                        //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                        if (i == 0)
                            min = eucSum;

                        if (eucSum < min)
                        {
                            min = eucSum;
                            index = i;
                        }

                    }
                    dataPtr[0] = imgVecB[index];
                    dataPtr[1] = imgVecG[index];
                    dataPtr[2] = imgVecR[index];

                    dataPtr -= nChan;
                    dataPtrCopy -= nChan;


                    //processar border inferior
                    for (x = 1; x < width - 1; x++)
                    {
                        imgVecB[0] = (dataPtrCopy - nChan - widthStep)[0];
                        imgVecG[0] = (dataPtrCopy - nChan - widthStep)[1];
                        imgVecR[0] = (dataPtrCopy - nChan - widthStep)[2];

                        imgVecB[1] = (dataPtrCopy - widthStep)[0];
                        imgVecG[1] = (dataPtrCopy - widthStep)[1];
                        imgVecR[1] = (dataPtrCopy - widthStep)[2];

                        imgVecB[2] = (dataPtrCopy - widthStep + nChan)[0];
                        imgVecG[2] = (dataPtrCopy - widthStep + nChan)[1];
                        imgVecR[2] = (dataPtrCopy - widthStep + nChan)[2];

                        imgVecB[3] = (dataPtrCopy - nChan)[0];
                        imgVecG[3] = (dataPtrCopy - nChan)[1];
                        imgVecR[3] = (dataPtrCopy - nChan)[2];

                        imgVecB[4] = (dataPtrCopy)[0];
                        imgVecG[4] = (dataPtrCopy)[1];
                        imgVecR[4] = (dataPtrCopy)[2];

                        imgVecB[5] = (dataPtrCopy + nChan)[0];
                        imgVecG[5] = (dataPtrCopy + nChan)[1];
                        imgVecR[5] = (dataPtrCopy + nChan)[2];

                        imgVecB[6] = (dataPtrCopy - nChan)[0];
                        imgVecG[6] = (dataPtrCopy - nChan)[1];
                        imgVecR[6] = (dataPtrCopy - nChan)[2];

                        imgVecB[7] = (dataPtrCopy)[0];
                        imgVecG[7] = (dataPtrCopy)[1];
                        imgVecR[7] = (dataPtrCopy)[2];

                        imgVecB[8] = (dataPtrCopy + nChan)[0];
                        imgVecG[8] = (dataPtrCopy + nChan)[1];
                        imgVecR[8] = (dataPtrCopy + nChan)[2];

                        min = 0;
                        index = 0;

                        for (i = 0; i < 9; i++)
                        {
                            eucSum = 0;
                            for (j = 0; j < 9; j++)
                                eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                            //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                            if (i == 0)
                                min = eucSum;

                            if (eucSum < min)
                            {
                                min = eucSum;
                                index = i;
                            }

                        }
                        dataPtr[0] = imgVecB[index];
                        dataPtr[1] = imgVecG[index];
                        dataPtr[2] = imgVecR[index];

                        dataPtr -= nChan;
                        dataPtrCopy -= nChan;
                    }

                    //processar pixel (0,N)

                    imgVecB[0] = (dataPtrCopy - widthStep)[0];
                    imgVecG[0] = (dataPtrCopy - widthStep)[1];
                    imgVecR[0] = (dataPtrCopy - widthStep)[2];

                    imgVecB[1] = (dataPtrCopy - widthStep)[0];
                    imgVecG[1] = (dataPtrCopy - widthStep)[1];
                    imgVecR[1] = (dataPtrCopy - widthStep)[2];

                    imgVecB[2] = (dataPtrCopy - widthStep + nChan)[0];
                    imgVecG[2] = (dataPtrCopy - widthStep + nChan)[1];
                    imgVecR[2] = (dataPtrCopy - widthStep + nChan)[2];

                    imgVecB[3] = (dataPtrCopy)[0];
                    imgVecG[3] = (dataPtrCopy)[1];
                    imgVecR[3] = (dataPtrCopy)[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy + nChan)[0];
                    imgVecG[5] = (dataPtrCopy + nChan)[1];
                    imgVecR[5] = (dataPtrCopy + nChan)[2];

                    imgVecB[6] = (dataPtrCopy)[0];
                    imgVecG[6] = (dataPtrCopy)[1];
                    imgVecR[6] = (dataPtrCopy)[2];

                    imgVecB[7] = (dataPtrCopy)[0];
                    imgVecG[7] = (dataPtrCopy)[1];
                    imgVecR[7] = (dataPtrCopy)[2];

                    imgVecB[8] = (dataPtrCopy + nChan)[0];
                    imgVecG[8] = (dataPtrCopy + nChan)[1];
                    imgVecR[8] = (dataPtrCopy + nChan)[2];

                    min = 0;
                    index = 0;
                    for (i = 0; i < 9; i++)
                    {
                        eucSum = 0;
                        for (j = 0; j < 9; j++)
                            eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                        //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                        if (i == 0)
                            min = eucSum;

                        if (eucSum < min)
                        {
                            min = eucSum;
                            index = i;
                        }

                    }
                    dataPtr[0] = imgVecB[index];
                    dataPtr[1] = imgVecG[index];
                    dataPtr[2] = imgVecR[index];

                    dataPtrCopy -= widthStep;
                    dataPtr -= widthStep;

                    //processar border esquerda
                    for (y = 1; y < height - 1; y++)
                    {
                        imgVecB[0] = (dataPtrCopy - widthStep)[0];
                        imgVecG[0] = (dataPtrCopy - widthStep)[1];
                        imgVecR[0] = (dataPtrCopy - widthStep)[2];

                        imgVecB[1] = (dataPtrCopy - widthStep)[0];
                        imgVecG[1] = (dataPtrCopy - widthStep)[1];
                        imgVecR[1] = (dataPtrCopy - widthStep)[2];

                        imgVecB[2] = (dataPtrCopy - widthStep + nChan)[0];
                        imgVecG[2] = (dataPtrCopy - widthStep + nChan)[1];
                        imgVecR[2] = (dataPtrCopy - widthStep + nChan)[2];

                        imgVecB[3] = (dataPtrCopy)[0];
                        imgVecG[3] = (dataPtrCopy)[1];
                        imgVecR[3] = (dataPtrCopy)[2];

                        imgVecB[4] = (dataPtrCopy)[0];
                        imgVecG[4] = (dataPtrCopy)[1];
                        imgVecR[4] = (dataPtrCopy)[2];

                        imgVecB[5] = (dataPtrCopy + nChan)[0];
                        imgVecG[5] = (dataPtrCopy + nChan)[1];
                        imgVecR[5] = (dataPtrCopy + nChan)[2];

                        imgVecB[6] = (dataPtrCopy - widthStep)[0];
                        imgVecG[6] = (dataPtrCopy - widthStep)[1];
                        imgVecR[6] = (dataPtrCopy - widthStep)[2];

                        imgVecB[7] = (dataPtrCopy - widthStep)[0];
                        imgVecG[7] = (dataPtrCopy - widthStep)[1];
                        imgVecR[7] = (dataPtrCopy - widthStep)[2];

                        imgVecB[8] = (dataPtrCopy + nChan - widthStep)[0];
                        imgVecG[8] = (dataPtrCopy + nChan - widthStep)[1];
                        imgVecR[8] = (dataPtrCopy + nChan - widthStep)[2];

                        min = 0;
                        index = 0;
                        for (i = 0; i < 9; i++)
                        {
                            eucSum = 0;
                            for (j = 0; j < 9; j++)
                                eucSum += Math.Abs((imgVecB[i] - imgVecB[j])) + Math.Abs((imgVecG[i] - imgVecG[j])) + Math.Abs((imgVecR[i] - imgVecR[j]));
                            //eucSum += Math.Sqrt((imgVecB[i] - imgVecB[j]) ^ 2 + (imgVecG[i] - imgVecG[j])^2 + (imgVecR[i] - imgVecR[j])^2);

                            if (i == 0)
                                min = eucSum;

                            if (eucSum < min)
                            {
                                min = eucSum;
                                index = i;
                            }

                        }

                        dataPtr[0] = imgVecB[index];
                        dataPtr[1] = imgVecG[index];
                        dataPtr[2] = imgVecR[index];
                        dataPtrCopy -= widthStep;
                        dataPtr -= widthStep;
                    }
                }

            }
        }

        public static void ConvertToBW(Emgu.CV.Image<Bgr, byte> img, int threshold)
        {
            unsafe
            {
                ConvertToGray(img);
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int sum = 0;
                int nC = m.nChannels;
                byte blue, green, red, gray;


                if (nC == 3)
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);
                            if (gray <= threshold)
                            {
                                dataPtr[0] = 0;
                                dataPtr[1] = 0;
                                dataPtr[2] = 0;
                            }

                            else
                            {
                                dataPtr[0] = 255;
                                dataPtr[1] = 255;
                                dataPtr[2] = 255;
                            }
                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void Thinning(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                ConvertToGray(img);
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int nC = m.nChannels;

                dataPtr += nChan + widthStep;
                if (nC == 3)
                {
                    for (int y = 1; y < height-1; y++)
                    {
                        for (int x = 1; x < width-1; x++)
                        {
                            if (dataPtr[0] == 255 && (dataPtr - widthStep - nChan)[0] == 0 && (dataPtr - widthStep)[0] == 0 && (dataPtr - widthStep + nChan)[0] == 0 && (dataPtr + widthStep - nChan)[0] == 255 && (dataPtr + widthStep)[0] == 255 && (dataPtr + widthStep + nChan)[0] == 255)
                                dataPtr[0] = 255;
                            else
                                dataPtr[0] = 0;
                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void ConvertToBW_Otsu(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                ConvertToGray(img);
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrReset = dataPtr;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int[] hist = new int[256];
                float[] sigma = new float[256];
                float[] prob = new float[256];
                int nC = m.nChannels;
                byte blue, green, red, gray;
                float q1 = 1;
                float q2 = 1;
                float diferenca = 0;
                double variancia;
                float u1 = 0;
                float u2 = 0;
                int t, i;
                int ip1 = 0;
                int ip2 = 0;
                int numPix;
                int sum = 0;
                double varMax = 0;
                int threshold = 0;

                numPix = width * height;
                if (nC == 3)
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            //vai ao index do hist que neste caso (int)dataPtr[0] e o valor do pixel 0 a 255
                            hist[gray]++;
                            // avança apontador
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }
                    for (i = 0; i < 256; i++)
                    {
                        prob[i] = (float)hist[i] / numPix;
                    }

                    for (t = 0; t < 256; t++)
                    {
                        for (i = 1; i <= t; i++)
                        {
                            q1 += prob[i];
                        }

                        q2 = 1 - q1;

                        for (i = 0; i <= t; i++)
                        {
                            u1 += i * prob[i];
                        }

                        for (i = t + 1; i < 256; i++)
                        {
                            u2 += i * prob[i];
                        }
                        if (q1 * q2 != 0)
                        {
                            diferenca = (u1 / q1) - (u2 / q2);
                            sigma[t] = q1 * q2 * (diferenca * diferenca);
                        }
                        else
                        {
                            sigma[t] = 0;
                        }

                        //reinicialize variables
                        q1 = 0;
                        q2 = 0;
                        u1 = 0;
                        u2 = 0;

                        //check for max
                        if (varMax < sigma[t])
                        {
                            varMax = sigma[t];
                            threshold = t;
                        }


                        //variancia = q1 * q2 * Math.Pow((u1 - u2), 2);

                        //if (variancia > varMax)
                        //{
                        //    threshold = t;
                        //    varMax = variancia;
                        //}



                    }
                    dataPtr = dataPtrReset;
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {

                            if (dataPtr[0] <= threshold)
                            {
                                dataPtr[0] = 0;
                                dataPtr[1] = 0;
                                dataPtr[2] = 0;
                            }

                            else
                            {
                                dataPtr[0] = 255;
                                dataPtr[1] = 255;
                                dataPtr[2] = 255;
                            }
                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }


                }
            }

        }

        public static void Mean_solutionB(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                MIplImage mCopy = imgCopy.MIplImage;

                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer();//Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int FirstBlueSum = 0, FirstGreenSum = 0, FirstRedSum = 0;
                int sumBlue = 0;
                int sumGreen = 0;
                int sumRed = 0;

                int nC = m.nChannels;
                if (nC == 3)//image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            if (x == 0 && y == 0)
                            { //top left corner--------------------------------
                                sumBlue = ((int)dataPtrCopy[0] * 4 + (dataPtrCopy + nC)[0] * 2 + (dataPtrCopy + widthStep)[0] * 2 + (dataPtrCopy + widthStep + nC)[0]);
                                sumGreen = ((int)dataPtrCopy[1] * 4 + (dataPtrCopy + nC)[1] * 2 + (dataPtrCopy + widthStep)[1] * 2 + (dataPtrCopy + widthStep + nC)[1]);
                                sumRed = ((int)dataPtrCopy[2] * 4 + (dataPtrCopy + nC)[2] * 2 + (dataPtrCopy + widthStep)[2] * 2 + (dataPtrCopy + widthStep + nC)[2]);


                                FirstBlueSum = sumBlue;
                                FirstGreenSum = sumGreen;
                                FirstRedSum = sumRed;
                            }
                            //top margin pixel after left corner OK
                            //retiramos 2 vezes os pixeis que anteriormente estavam a ser usados usando duplicação de margens e substituimos pelos adjacentes agora usados
                            //---------------------------------------------------------------------------
                            else if (x == 1 && y == 0)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - nC)[0] * 2 - (dataPtrCopy - nC + widthStep)[0] + (dataPtrCopy + nC)[0] * 2 + (dataPtrCopy + nC + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - nC)[1] * 2 - (dataPtrCopy - nC + widthStep)[1] + (dataPtrCopy + nC)[1] * 2 + (dataPtrCopy + nC + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - nC)[2] * 2 - (dataPtrCopy - nC + widthStep)[2] + (dataPtrCopy + nC)[2] * 2 + (dataPtrCopy + nC + widthStep)[2];
                            }
                            //top right corner OK
                            else if (x == width - 1 && y == 0)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC)[0] * 2 - (dataPtrCopy - 2 * nC + widthStep)[0] + dataPtrCopy[0] * 2 + (dataPtrCopy + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC)[1] * 2 - (dataPtrCopy - 2 * nC + widthStep)[1] + dataPtrCopy[1] * 2 + (dataPtrCopy + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC)[2] * 2 - (dataPtrCopy - 2 * nC + widthStep)[2] + dataPtrCopy[2] * 2 + (dataPtrCopy + widthStep)[2];
                            }
                            //bot left corner OK
                            else if (x == 0 && y == height - 1)
                            {
                                sumBlue = FirstBlueSum - (dataPtrCopy - 2 * widthStep)[0] * 2 - (dataPtrCopy - 2 * widthStep + nC)[0] + dataPtrCopy[0] * 2 + (dataPtrCopy + nC)[0];
                                sumGreen = FirstGreenSum - (dataPtrCopy - 2 * widthStep)[1] * 2 - (dataPtrCopy - 2 * widthStep + nC)[1] + dataPtrCopy[1] * 2 + (dataPtrCopy + nC)[1];
                                sumRed = FirstRedSum - (dataPtrCopy - 2 * widthStep)[2] * 2 - (dataPtrCopy - 2 * widthStep + nC)[2] + dataPtrCopy[2] * 2 + (dataPtrCopy + nC)[2];
                            }
                            //bot margin pixel after left corner OK
                            else if (x == 1 && y == height - 1)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - nC)[0] * 2 - (dataPtrCopy - widthStep - nC)[0] + (dataPtrCopy - widthStep + nC)[0] + (dataPtrCopy + nC)[0] * 2;
                                sumGreen = sumGreen - (dataPtrCopy - nC)[1] * 2 - (dataPtrCopy - widthStep - nC)[1] + (dataPtrCopy - widthStep + nC)[1] + (dataPtrCopy + nC)[1] * 2;
                                sumRed = sumRed - (dataPtrCopy - nC)[2] * 2 - (dataPtrCopy - widthStep - nC)[2] + (dataPtrCopy - widthStep + nC)[2] + (dataPtrCopy + nC)[2] * 2;
                            }
                            //bot right corner OK
                            else if (x == width - 1 && y == height - 1)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC)[0] * 2 - (dataPtrCopy - widthStep - 2 * nC)[0] + (dataPtrCopy)[0] * 2 + (dataPtrCopy - widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC)[1] * 2 - (dataPtrCopy - widthStep - 2 * nC)[1] + (dataPtrCopy)[1] * 2 + (dataPtrCopy - widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC)[2] * 2 - (dataPtrCopy - widthStep - 2 * nC)[2] + (dataPtrCopy)[2] * 2 + (dataPtrCopy - widthStep)[2];
                            }
                            //left margin pixel after top left corner OK
                            else if (x == 0 && y == 1)
                            {
                                sumBlue = FirstBlueSum - (dataPtrCopy - widthStep)[0] * 2 - (dataPtrCopy - widthStep + nC)[0] + (dataPtrCopy + widthStep)[0] * 2 + (dataPtrCopy + widthStep + nC)[0];
                                sumGreen = FirstGreenSum - (dataPtrCopy - widthStep)[1] * 2 - (dataPtrCopy - widthStep + nC)[1] + (dataPtrCopy + widthStep)[1] * 2 + (dataPtrCopy + widthStep + nC)[1];
                                sumRed = FirstRedSum - (dataPtrCopy - widthStep)[2] * 2 - (dataPtrCopy - widthStep + nC)[2] + (dataPtrCopy + widthStep)[2] * 2 + (dataPtrCopy + widthStep + nC)[2];

                                FirstBlueSum = sumBlue;
                                FirstGreenSum = sumGreen;
                                FirstRedSum = sumRed;
                            }
                            //top margin OK
                            else if (y == 0)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC)[0] * 2 - (dataPtrCopy - 2 * nC + widthStep)[0] + (dataPtrCopy + nC)[0] * 2 + (dataPtrCopy + nC + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC)[1] * 2 - (dataPtrCopy - 2 * nC + widthStep)[1] + (dataPtrCopy + nC)[1] * 2 + (dataPtrCopy + nC + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC)[2] * 2 - (dataPtrCopy - 2 * nC + widthStep)[2] + (dataPtrCopy + nC)[2] * 2 + (dataPtrCopy + nC + widthStep)[2];
                            }
                            //bottom margin OK
                            else if (y == height - 1)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC)[0] * 2 - (dataPtrCopy - 2 * nC - widthStep)[0] + (dataPtrCopy + nC)[0] * 2 + (dataPtrCopy + nC - widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC)[1] * 2 - (dataPtrCopy - 2 * nC - widthStep)[1] + (dataPtrCopy + nC)[1] * 2 + (dataPtrCopy + nC - widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC)[2] * 2 - (dataPtrCopy - 2 * nC - widthStep)[2] + (dataPtrCopy + nC)[2] * 2 + (dataPtrCopy + nC - widthStep)[2];
                            }
                            //left margin
                            else if (x == 0)
                            {
                                sumBlue = FirstBlueSum - (dataPtrCopy - 2 * widthStep)[0] * 2 - (dataPtrCopy - 2 * widthStep + nC)[0] + (dataPtrCopy + widthStep)[0] * 2 + (dataPtrCopy + widthStep + nC)[0];
                                sumGreen = FirstGreenSum - (dataPtrCopy - 2 * widthStep)[1] * 2 - (dataPtrCopy - 2 * widthStep + nC)[1] + (dataPtrCopy + widthStep)[1] * 2 + (dataPtrCopy + widthStep + nC)[1];
                                sumRed = FirstRedSum - (dataPtrCopy - 2 * widthStep)[2] * 2 - (dataPtrCopy - 2 * widthStep + nC)[2] + (dataPtrCopy + widthStep)[2] * 2 + (dataPtrCopy + widthStep + nC)[2];

                                FirstBlueSum = sumBlue;
                                FirstGreenSum = sumGreen;
                                FirstRedSum = sumRed;
                            }
                            //right margin
                            else if (x == width - 1)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC - widthStep)[0] - (dataPtrCopy - 2 * nC)[0] - (dataPtrCopy - 2 * nC + widthStep)[0] + (dataPtrCopy - widthStep)[0] + dataPtrCopy[0] + (dataPtrCopy + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC - widthStep)[1] - (dataPtrCopy - 2 * nC)[1] - (dataPtrCopy - 2 * nC + widthStep)[1] + (dataPtrCopy - widthStep)[1] + dataPtrCopy[1] + (dataPtrCopy + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC - widthStep)[2] - (dataPtrCopy - 2 * nC)[2] - (dataPtrCopy - 2 * nC + widthStep)[2] + (dataPtrCopy - widthStep)[2] + dataPtrCopy[2] + (dataPtrCopy + widthStep)[2];
                            }
                            //second collumn
                            else if (x == 1)
                            {
                                sumBlue = sumBlue - (dataPtrCopy - nC - widthStep)[0] - (dataPtrCopy - nC)[0] - (dataPtrCopy - nC + widthStep)[0] + (dataPtrCopy + nC - widthStep)[0] + (dataPtrCopy + nC)[0] + (dataPtrCopy + nC + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - nC - widthStep)[1] - (dataPtrCopy - nC)[1] - (dataPtrCopy - nC + widthStep)[1] + (dataPtrCopy + nC - widthStep)[1] + (dataPtrCopy + nC)[1] + (dataPtrCopy + nC + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - nC - widthStep)[2] - (dataPtrCopy - nC)[2] - (dataPtrCopy - nC + widthStep)[2] + (dataPtrCopy + nC - widthStep)[2] + (dataPtrCopy + nC)[2] + (dataPtrCopy + nC + widthStep)[2];
                            }
                            //center pixels
                            else
                            {
                                sumBlue = sumBlue - (dataPtrCopy - 2 * nC - widthStep)[0] - (dataPtrCopy - 2 * nC)[0] - (dataPtrCopy - 2 * nC + widthStep)[0] + (dataPtrCopy + nC - widthStep)[0] + (dataPtrCopy + nC)[0] + (dataPtrCopy + nC + widthStep)[0];
                                sumGreen = sumGreen - (dataPtrCopy - 2 * nC - widthStep)[1] - (dataPtrCopy - 2 * nC)[1] - (dataPtrCopy - 2 * nC + widthStep)[1] + (dataPtrCopy + nC - widthStep)[1] + (dataPtrCopy + nC)[1] + (dataPtrCopy + nC + widthStep)[1];
                                sumRed = sumRed - (dataPtrCopy - 2 * nC - widthStep)[2] - (dataPtrCopy - 2 * nC)[2] - (dataPtrCopy - 2 * nC + widthStep)[2] + (dataPtrCopy + nC - widthStep)[2] + (dataPtrCopy + nC)[2] + (dataPtrCopy + nC + widthStep)[2];
                            }
                            dataPtr[0] = (byte)(Math.Round(sumBlue / 9.0));
                            dataPtr[1] = (byte)(Math.Round(sumGreen / 9.0));
                            dataPtr[2] = (byte)(Math.Round(sumRed / 9.0));

                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += padding;
                        dataPtr += padding;
                    }
                }

            }
        }


        /// <summary>
        /// License plate recognition
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgCopy"></param>
        /// <param name="difficultyLevel">Difficulty level 1-4</param>
        /// <param name="Type">LP type (A or B)</param>
        /// <param name="LP_Location"></param>
        /// <param name="LP_Chr1"></param>
        /// <param name="LP_Chr2"></param>
        /// <param name="LP_Chr3"></param>
        /// <param name="LP_Chr4"></param>
        /// <param name="LP_Chr5"></param>
        /// <param name="LP_Chr6"></param>
        /// <param name="LP_C1"></param>
        /// <param name="LP_C2"></param>
        /// <param name="LP_C3"></param>
        /// <param name="LP_C4"></param>
        /// <param name="LP_C5"></param>
        /// <param name="LP_C6"></param>
        public static void LP_Recognition(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy,
        int difficultyLevel,
         //string LPType,
         out Rectangle LP_Location,
         out Rectangle LP_Chr1,
         out Rectangle LP_Chr2,
         out Rectangle LP_Chr3,
         out Rectangle LP_Chr4,
         out Rectangle LP_Chr5,
         out Rectangle LP_Chr6
         //out string LP_C1,
         //out string LP_C2,
         //out string LP_C3,
         //out string LP_C4,
         //out string LP_C5,
         //out string LP_C6

      )
        {
            unsafe
            {
                int i, max, index;
                int k = 0;
                int xi = 0;
                int xf = 0;
                int yi = 0;
                int yf = 0;
                int yiPlate = 0;
                int yfPlate = 0;
                int xiPlate = 0;
                int xfPlate = 0;
                int yPlateDiff = 0;
                int xPlateDiff = 0;
                int[] compare = new int[35];
                MIplImage m = img.MIplImage;
                bool pos = false;
                bool posy = false;
                bool posCY = false;
                bool posCX = false;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                int[] projectionX = new int[m.width + 1];
                int[] projectionY = new int[m.height + 1];
                int[] projectionXWhite = new int[m.width + 1];
                int[] contrastX = new int[m.width];
                int[] contrastY = new int[m.height];
                float[,] nonUniformMatrix = new float[3, 3];
                //char[] plate = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','A', 'B','C','D' ,'E','T' };
                char[] plate = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                           'A','B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                                           'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                                           'X', 'Z'};
                List<Image<Bgr, Byte>> symbols = new List<Image<Bgr, byte>>();
                List<MIplImage> s = new List<MIplImage>();
                List<Rectangle> r = new List<Rectangle>();
                Image<Bgr, byte> img_type1 = null;
                Image<Bgr, byte> img_type2Y = null;
                Image<Bgr, byte> img_type2X = null;
                Image<Bgr, byte> img_type2YCopy = null;
                Image<Bgr, byte> img_type2XCopy = null;
                Image<Bgr, byte> img_plate = null;
                Image<Bgr, byte> ch = null;




                LP_Location = new Rectangle(220, 190, 200, 40);

                LP_Chr1 = new Rectangle(340, 190, 30, 40);
                LP_Chr2 = new Rectangle(360, 190, 30, 40);
                LP_Chr3 = new Rectangle(380, 190, 30, 40);
                LP_Chr4 = new Rectangle(400, 190, 30, 40);
                LP_Chr5 = new Rectangle(420, 190, 30, 40);
                LP_Chr6 = new Rectangle(440, 190, 30, 40);

                //r.Add(LP_Chr1);
                //r.Add(LP_Chr2);
                //r.Add(LP_Chr3);
                //r.Add(LP_Chr4);
                //r.Add(LP_Chr5);
                //r.Add(LP_Chr6);



                //LP_C1 = "1";
                //LP_C2 = "2";
                //LP_C3 = "3";
                //LP_C4 = "4";
                //LP_C5 = "5";
                //LP_C6 = "6";




                Image<Bgr, byte> n0 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\0.bmp");
                Image<Bgr, byte> n1 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\1.bmp");
                Image<Bgr, byte> n2 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\2.bmp");
                Image<Bgr, byte> n3 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\3.bmp");
                Image<Bgr, byte> n4 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\4.bmp");
                Image<Bgr, byte> n5 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\5.bmp");
                Image<Bgr, byte> n6 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\6.bmp");
                Image<Bgr, byte> n7 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\7.bmp");
                Image<Bgr, byte> n8 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\8.bmp");
                Image<Bgr, byte> n9 = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\9.bmp");
                Image<Bgr, byte> na = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\A.bmp");
                Image<Bgr, byte> nb = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\B.bmp");
                Image<Bgr, byte> nc = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\C.bmp");
                Image<Bgr, byte> nd = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\D.bmp");
                Image<Bgr, byte> ne = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\E.bmp");
                Image<Bgr, byte> nf = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\F.bmp");
                Image<Bgr, byte> ng = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\G.bmp");
                Image<Bgr, byte> nh = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\H.bmp");
                Image<Bgr, byte> ni = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\I.bmp");
                Image<Bgr, byte> nj = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\J.bmp");
                Image<Bgr, byte> nk = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\K.bmp");
                Image<Bgr, byte> nl = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\L.bmp");
                Image<Bgr, byte> nm = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\M.bmp");
                Image<Bgr, byte> nn = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\N.bmp");
                Image<Bgr, byte> no = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\O.bmp");
                Image<Bgr, byte> np = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\P.bmp");
                Image<Bgr, byte> nq = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\Q.bmp");
                Image<Bgr, byte> nr = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\R.bmp");
                Image<Bgr, byte> ns = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\S.bmp");
                Image<Bgr, byte> nt = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\T.bmp");
                Image<Bgr, byte> nu = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\U.bmp");
                Image<Bgr, byte> nv = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\V.bmp");
                Image<Bgr, byte> nx = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\X.bmp");
                Image<Bgr, byte> nz = new Image<Bgr, byte>("C:\\Users\\mykyt\\source\\repos\\SS\\SS_OpenCV_2021_10_05\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\Z.bmp");
                //Image<Bgr, byte> n0 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\0.bmp");
                //Image<Bgr, byte> n1 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\1.bmp");
                //Image<Bgr, byte> n2 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\2.bmp");
                //Image<Bgr, byte> n3 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\3.bmp");
                //Image<Bgr, byte> n4 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\4.bmp");
                //Image<Bgr, byte> n5 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\5.bmp");
                //Image<Bgr, byte> n6 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\6.bmp");
                //Image<Bgr, byte> n7 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\7.bmp");
                //Image<Bgr, byte> n8 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\8.bmp");
                //Image<Bgr, byte> n9 = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\9.bmp");
                //Image<Bgr, byte> na = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\A.bmp");
                //Image<Bgr, byte> nb = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\B.bmp");
                //Image<Bgr, byte> nc = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\C.bmp");
                //Image<Bgr, byte> nd = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\D.bmp");
                //Image<Bgr, byte> ne = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\E.bmp");
                //Image<Bgr, byte> nf = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\F.bmp");
                //Image<Bgr, byte> ng = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\G.bmp");
                //Image<Bgr, byte> nh = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\H.bmp");
                //Image<Bgr, byte> ni = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\I.bmp");
                //Image<Bgr, byte> nj = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\J.bmp");
                //Image<Bgr, byte> nk = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\K.bmp");
                //Image<Bgr, byte> nl = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\L.bmp");
                //Image<Bgr, byte> nm = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\M.bmp");
                //Image<Bgr, byte> nn = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\N.bmp");
                //Image<Bgr, byte> no = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\O.bmp");
                //Image<Bgr, byte> np = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\P.bmp");
                //Image<Bgr, byte> nq = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\Q.bmp");
                //Image<Bgr, byte> nr = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\R.bmp");
                //Image<Bgr, byte> ns = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\S.bmp");
                //Image<Bgr, byte> nt = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\T.bmp");
                //Image<Bgr, byte> nu = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\U.bmp");
                //Image<Bgr, byte> nv = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\V.bmp");
                //Image<Bgr, byte> nx = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\X.bmp");
                //Image<Bgr, byte> nz = new Image<Bgr, byte>("D:\\joaom\\Documents\\Mestrado\\SS\\SS_OpenCV_2021_10_05\\SS_OpenCV_Base\\BD\\Z.bmp");
                Image<Bgr, byte> diff = null;
                Image<Bgr, byte> BD = null;




                symbols.Add(n0);
                symbols.Add(n1);
                symbols.Add(n2);
                symbols.Add(n3);
                symbols.Add(n4);
                symbols.Add(n5);
                symbols.Add(n6);
                symbols.Add(n7);
                symbols.Add(n8);
                symbols.Add(n9);


                symbols.Add(na);
                symbols.Add(nb);
                symbols.Add(nc);
                symbols.Add(nd);
                symbols.Add(ne);
                symbols.Add(nf);
                symbols.Add(ng);
                symbols.Add(nh);
                symbols.Add(ni);
                symbols.Add(nj);
                symbols.Add(nk);
                symbols.Add(nl);
                symbols.Add(nm);
                symbols.Add(nn);
                symbols.Add(no);
                symbols.Add(np);
                symbols.Add(nq);
                symbols.Add(nr);
                symbols.Add(ns);
                symbols.Add(nt);
                symbols.Add(nu);
                symbols.Add(nv);
                symbols.Add(nx);
                symbols.Add(nz);


                nonUniformMatrix[0, 0] = 0;
                nonUniformMatrix[0, 1] = 0;
                nonUniformMatrix[0, 2] = 0;
                nonUniformMatrix[1, 0] = -1;
                nonUniformMatrix[1, 1] = 2;
                nonUniformMatrix[1, 2] = -1;
                nonUniformMatrix[2, 0] = 0;
                nonUniformMatrix[2, 1] = 0;
                nonUniformMatrix[2, 2] = 0;



                // guarda na lista s, a MIplImage de cada numero de matricula possivel
                for (i = 0; i < symbols.Count; i++)
                    s.Add(symbols[i].MIplImage);

                for (i = 0; i < symbols.Count; i++)
                    ConvertToBW_Otsu(symbols[i]);



                if (difficultyLevel == 2)
                {
                    img_type2Y = img.Copy();
                    img_type2YCopy = img_type2Y.Copy();
                    NonUniform(img_type2Y, img_type2YCopy, nonUniformMatrix, 1, 0); //aplicação de filtro nao uniforme
                    img_type2Y.Save("nonuniform.bmp");


                    contrastY = ContrastLineY(img_type2Y); //vector de contrastes entre pretos e brancos
                    for (i = 0; i < contrastY.Length; i++)
                    {
                        if (contrastY[i] > 5 && posCY == false)
                        {
                            posCY = true;
                            yiPlate = i;

                        }                                               //limites da matricula em Y

                        if (contrastY[i] < 2 && posCY == true)
                        {
                            posCY = false;
                            yfPlate = i;
                            break;


                        }
                    }
                    yiPlate -= 10;
                    yPlateDiff = yfPlate - yiPlate;
                    yPlateDiff += 10;
                    img.ROI = new Rectangle(0, yiPlate, img_type2Y.Width, yPlateDiff);  //recorte e Y
                    img.Save("plate_corteY.bmp");


                    img_type2X = img.Copy();  //passagem da regiao de intresse para uma nova imagem em que se realizara o recorte em x
                    img_type2XCopy = img_type2X.Copy(); 
                    Diferentiation(img_type2X, img_type2XCopy);    // diferenciacao
                    ColorFilter(img_type2X);                        //filtro de cor
                    img_type2X.Save("Diferentiation.bmp");
                    projectionXWhite = ProjectionXWhite(img_type2X);    //projecao do numero de pixeis brancos
                    for (i = 0; i < contrastX.Length; i++)
                    {
                        if (!posCX && projectionXWhite[i] > 20)
                        {
                            posCX = true;
                            xiPlate = i;
                        }                                               //limites em X

                        if (posCX && projectionXWhite[i] > 20)
                            xfPlate = i;
                    }
                    xPlateDiff = xfPlate - xiPlate;
                    xPlateDiff += 10;
                    xiPlate -= 10;
                    img.ROI = new Rectangle(xiPlate, yiPlate, xPlateDiff, yPlateDiff);  //recorte em x e em Y
                    img_plate = img.Copy();                 //passagem da regiao de interesse para uma nova imagem que so contém a matricula
                    img.Save("Plate.bmp");  
                    LP_Location = img.ROI;              


                }else if(difficultyLevel == 1){
                    img_plate = img.Copy();         //se a imagem for de dif. 1, a regiao de interesse da matricula é a imagem completa
                }




                ConvertToBW_Otsu(img_plate);        //binarizacao da imagem da matricula
                img_plate.Save("fgdgdf.bmp");
                if(difficultyLevel == 1)
                    projectionX = ProjectionX(img_plate, 21); //dificult lvl 1          a nova funcao mete a zero tudo abaixo do threshold
                                                                                       //para ser mais fácil de processar no codigo abaixo
                else if(difficultyLevel == 2)
                    projectionX = ProjectionX(img_plate, 15); //dificult lvl 2

                projectionY = ProjectionY(img_plate);


                for (i = 0; i < projectionY.Length; i++)
                {
                    if (projectionY[i] > 50 && posy == false)
                    {
                        posy = true;
                        yi = i;

                    }
                                                                        //recorte do caractere i em Y
                    if (projectionY[i] < 50 && posy == true)
                    {
                        posy = false;
                        yf = i;
                        break;


                    }
                }


                for (i = 0; i < projectionX.Length; i++)
                {
                    if (projectionX[i] > 0 && pos == false)
                    {
                        pos = true;
                        xi = i;

                    }

                    if ((projectionX[i] == 0 || i==(projectionX.Length)-1) && pos == true)      //recorte do caractere i em x
                                                                                               //se for zero ou se chegar ao fim do vector, pq muitas vezes o vectr nao acaba em zero e da erro de acesso a memoria
                    {
                        pos = false;
                        xf = i;

                        img.ROI = new Rectangle(xiPlate + xi, yiPlate + yi, xf - xi, yf - yi); //recorte do caractere em coordenadas da imagem original
                                                                                               //no caso de dif 1 fica sem efeito pq a xiPlate é inicializado a zero
                        img.Save("ch.bmp");
                        ch = img.Copy();
                        ConvertToBW_Otsu(ch);
                        ch.Save("ch.bmp");
                        r.Add ( img.ROI);


                        for (int j = 0; j < symbols.Count; j++)
                        {
                            BD = symbols[j].Resize(ch.Width, ch.Height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);  //comparacao
                            compare[j] = Compare_Caracter(ch, BD);
                        }
                        
                        max = compare.Max();
                        index = Array.IndexOf(compare, max);
                        Console.WriteLine(plate[index]);
                       
                        Array.Clear(compare, 0, compare.Length);
                    }

                }


                LP_Chr1 = r[0];
                LP_Chr2 = r[1];
                LP_Chr3 = r[2];
                LP_Chr4 = r[3];
                LP_Chr5 = r[4];
                LP_Chr6 = r[5];

            }
        }

        public static void DetectPlateY(Emgu.CV.Image<Bgr, byte> img)
        {

            unsafe
            {
                MIplImage m = img.MIplImage;

                float[,] nonUniformMatrix = new float[3, 3];
                float[,] nonUniformMatrix2 = new float[3, 3];

                Image<Bgr, byte> img_type1 = null;
                Image<Bgr, byte> img_type2Y = null;
                Image<Bgr, byte> img_type2X = null;
                Image<Bgr, byte> img_type2YCopy = null;
                Image<Bgr, byte> img_type2XCopy = null;
                Image<Bgr, byte> img_plate = null;

                nonUniformMatrix[0, 0] = 0;
                nonUniformMatrix[0, 1] = 0;
                nonUniformMatrix[0, 2] = 0;
                nonUniformMatrix[1, 0] = -1;
                nonUniformMatrix[1, 1] = 2;
                nonUniformMatrix[1, 2] = -1;
                nonUniformMatrix[2, 0] = 0;
                nonUniformMatrix[2, 1] = 0;
                nonUniformMatrix[2, 2] = 0;

                nonUniformMatrix2[0, 0] = 0;
                nonUniformMatrix2[0, 1] = -1;
                nonUniformMatrix2[0, 2] = 0;
                nonUniformMatrix2[1, 0] = 0;
                nonUniformMatrix2[1, 1] = 2;
                nonUniformMatrix2[1, 2] = 0;
                nonUniformMatrix2[2, 0] = 0;
                nonUniformMatrix2[2, 1] = -1;
                nonUniformMatrix2[2, 2] = 0;

                Image<Bgr, byte>  aux = img.Copy();

                img_type2Y = img.Copy();
                img_type2YCopy = img_type2Y.Copy();
                NonUniform(img_type2Y, img_type2YCopy, nonUniformMatrix, 1, 0); //aplicação de filtro nao uniforme

                img_type2YCopy = img_type2Y.Copy();

                Mean(img_type2Y, img_type2YCopy);

                ColorFilter(img_type2Y);

                img_type2YCopy = img_type2Y.Copy();

                Sobel(img_type2Y, img_type2YCopy);

                img_type2YCopy = img_type2Y.Copy();

                ConvertToBW(img_type2Y, 100);

                img_type2Y.Save("afterEffects.bmp"); // image saved after all filters

                int[] histy = new int[m.height];

                bool posCY = false;
                int yiPlate = 0, yfPlate = 0, yPlateDiff = 0;
                int yiPlateAux = 0, yPlateDiffAux = 0;

                histy = ProjectionYWhite(img_type2Y);

                int tresh = (int) histy.Average();
                int imgCounter = 0;

                for (int i = 0; i < histy.Length; i++)
                {
                    if (histy[i] > tresh && posCY == false)
                    {
                        posCY = true;
                        yiPlate = i;

                    }                                               //limites da matricula em Y
                    if (histy[i] < tresh && posCY == true)
                    {
                        posCY = false;
                        yfPlate = i;
                        yiPlate -= 10;
                        yPlateDiff = yfPlate - yiPlate;
                        yPlateDiff += 10;
                        if(yPlateDiff > 40)
                        {
                            yiPlateAux = yiPlate;
                            yPlateDiffAux = yPlateDiff;
                            img.ROI = new Rectangle(0, yiPlate, img_type2Y.Width, yPlateDiff);
                            img.Save("afterEffectsy" + imgCounter.ToString() +  ".bmp");
                            imgCounter++;
                        }
                    }
                }

                img.Save("afterEffectsypilaaaaa" + imgCounter.ToString() + ".bmp");

                img_type2X = img.Copy();
                img_type2XCopy = img_type2X.Copy();

                NonUniform(img_type2X, img_type2XCopy, nonUniformMatrix2, 1, 0); //aplicação de filtro nao uniforme

                img_type2XCopy = img_type2X.Copy();

                Mean(img_type2X, img_type2XCopy);

                img_type2XCopy = img_type2X.Copy();

                Sobel(img_type2X, img_type2XCopy);

                img_type2XCopy = img_type2X.Copy();

                ColorFilter(img_type2X);

                img_type2XCopy = img_type2X.Copy();

                ConvertToBW(img_type2X, 100);

                int[] histx = new int[m.width];

                bool posCX = false;
                int xiPlate = 0, xfPlate = 0, xPlateDiff = 0;

                histx = ProjectionXWhite(img_type2X);

                tresh = (int)histx.Average();
                imgCounter = 0;

                //for (int i = 0; i < histx.Length; i++)
                //{
                //    if (histx[i] > tresh && posCX == false)
                //    {
                //        posCX = true;
                //        xiPlate = i;

                //    }                                               //limites da matricula em Y
                //    if (histx[i] < tresh && posCX == true)
                //    {
                //        posCX = false;
                //        xfPlate = i;
                //        xPlateDiff = xfPlate - xiPlate;
                //        xiPlate -= 10;
                //        xPlateDiff += 10;
                //        if(xPlateDiff > 50)
                //        {
                //            aux.ROI = new Rectangle(xiPlate, yiPlateAux, xPlateDiff, yPlateDiffAux);
                //            aux.Save("afterEffectsx" + imgCounter.ToString() + ".bmp");
                //            imgCounter++;
                //        }
                //    }
                //}

                int xfFinal = 0, xiFinal = 0;

                for (int i = 0; i < histx.Length; i++)
                {
                    if (histx[i] > tresh && posCX == false)
                    {
                        if(i-xfPlate < 20 && i != 0)
                        {
                            posCX = true;
                        }
                        else
                        {
                            xiPlate = i;
                            posCX = true;
                        }
                    }                                               //limites da matricula em Y
                    if (histx[i] < tresh && posCX == true)
                    {
                        posCX = false;
                        xfPlate = i;

                        if (xfPlate - xiPlate > 150)
                        {
                            xfFinal = xfPlate;
                            xiFinal = xiPlate;
                        }
                    }
                }

                xPlateDiff = xfFinal - xiFinal;
                if (xPlateDiff > 50)
                {
                    img.ROI = new Rectangle(xiFinal, yiPlateAux, xPlateDiff, yPlateDiffAux);
                    img.Save("afterEffectsx" + imgCounter.ToString() + ".bmp");
                }
            }
        }

        public static int []ContrastLineX(Emgu.CV.Image<Bgr, byte> img)
        {

            unsafe
            {
                Image<Bgr, byte> imgCopy = null;
                imgCopy = img.Copy();
                imgCopy.ROI = new Rectangle(0, (imgCopy.Height) / 5, imgCopy.Width, (imgCopy.Height) * 3 / 5);

                MIplImage m = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                //int[] hist = new int[height];
                int[] hist = new int[width];
                int count = 0;
                bool toggle = false;

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (toggle && dataPtr[0] > 20)
                        {
                            //hist[y]++;
                            hist[x]++;
                            toggle = false;
                        }
                        if (!toggle && dataPtr[0] > 100)
                            toggle = true;

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
                //ProjectionY projectionY = new ProjectionY(hist, height);
                ////projectionY.ShowDialog();
                ProjectionX projectionX = new ProjectionX(hist, width);
                projectionX.ShowDialog();

                return hist;

            }
        }

        public static int[] ContrastLineY(Emgu.CV.Image<Bgr, byte> img)
        {

            unsafe
            {
                Image<Bgr, byte> imgCopy = null;
                imgCopy = img.Copy();
                imgCopy.ROI = new Rectangle(0, (imgCopy.Height) / 5, imgCopy.Width, (imgCopy.Height) * 3 / 5);

                MIplImage m = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;
                int[] hist = new int[height];
                //hist.Initialize();

                int count = 0;
                bool toggle = false;

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (toggle && dataPtr[0] > 20)
                        {
                            hist[y]++;

                            toggle = false;
                        }
                        if (!toggle && dataPtr[0] > 100)
                            toggle = true;

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
                ProjectionY projectionY = new ProjectionY(hist, height);
                projectionY.ShowDialog();


                return hist;

            }
        }

        public static int Compare_Caracter(Image<Bgr, byte> img, Image<Bgr, byte> character)
        {

            unsafe
            {
                MIplImage m = img.MIplImage;
                MIplImage c = character.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte* charPtr = (byte*)c.imageData.ToPointer(); // Pointer to the image
                int heightch = c.height;
                int widthch = c.width;
                int height = m.height;
                int width = m.width;
                int padding = m.widthStep - m.nChannels * m.width;
                int nChan = m.nChannels;
                int x, y;
                int equal = 0;
                int size = height * width;
                int result = 0;

                //ConvertToBW_Otsu(img);
                //ConvertToBW_Otsu(character);

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (dataPtr[0] == charPtr[0])
                            equal++;
                        dataPtr += nChan;
                        charPtr += nChan;

                    }
                    dataPtr += padding;
                    charPtr += padding;
                }

                return equal;
            }

        }

        public static int[] ProjectionY(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                int[] hist = new int[height];

               //ConvertToBW_Otsu(img);

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        hist[y] += dataPtr[0] == 255 ? 0 : 1;
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

                ProjectionY projectionY = new ProjectionY(hist, height);
                projectionY.ShowDialog();
                return hist;
            }
        }

        // tem de retornar alguma coisa ou deixar como void????
        public static int[] ProjectionX(Emgu.CV.Image<Bgr, byte> img, int treshold)
        {
            unsafe
            {

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                int[] hist = new int[width];

                //ConvertToBW_Otsu(img);

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        hist[x] += dataPtr[0] == 255 ? 0 : 1;
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

                for(x = 0; x < hist.Length; x++)
                {
                    if (hist[x] < treshold)
                        hist[x] = 0;
                }

                ProjectionX projectionX = new ProjectionX(hist, width);
                projectionX.ShowDialog();

                return hist;
            }
        }

        public static int[] ProjectionYWhite(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                int[] hist = new int[height];

                //ConvertToBW_Otsu(img);

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        hist[y] += dataPtr[0] < 50 ? 0 : 1;
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

                int treshold = (int) hist.Average();

                for (y = 0; y < height; y++)
                {
                    hist[y] = hist[y] < treshold ? 0 : hist[y];
                }

                ProjectionY projectionY = new ProjectionY(hist, height);
                projectionY.ShowDialog();
                return hist;
            }
        }

        // tem de retornar alguma coisa ou deixar como void????
        public static int[] ProjectionXWhite(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthStep = m.widthStep;
                int x, y;

                int[] hist = new int[width];

                //ConvertToBW_Otsu(img);

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        hist[x] += dataPtr[0] < 50 ? 0 : 1;
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

                int treshold = (int)hist.Average();

                for (x = 0; x < width; x++)
                {
                    hist[x] = hist[x] < treshold ? 0 : hist[x];
                }

                ProjectionX projectionX = new ProjectionX(hist, width);
                projectionX.ShowDialog();

                return hist;
            }
        }

        public static void ColorFilter(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                int threshold = 30;



                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            if ((Math.Abs(blue - green) + Math.Abs(blue - red) + Math.Abs(green - red)) > threshold)
                            {
                                dataPtr[0] = 0;
                                dataPtr[1] = 0;
                                dataPtr[2] = 0;

                            }



                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }
        /// <summary>
        /// Barcode reader - SS final project
        /// </summary>
        /// <param name="img">Original image</param>
        /// <param name="type">image type</param>
        /// <param name="bc_centroid1">output the centroid of the first barcode </param>
        /// <param name="bc_size1">output the size of the first barcode </param>
        /// <param name="bc_image1">output a string containing the first barcode read from the bars</param>
        /// <param name="bc_number1">output a string containing the first barcode read from the numbers in the bottom</param>
        /// <param name="bc_centroid2">output the centroid of the second barcode </param>
        /// <param name="bc_size2">output the size of the second barcode</param>       
        /// <param name="bc_image2">output a string containing the second barcode read from the bars. It returns null, if it does not exist.</param>
        /// <param name="bc_number2">output a string containing the second barcode read from the numbers in the bottom. It returns null, if it does not exist.</param>
        /// <returns>image with barcodes detected</returns>
    }
}
