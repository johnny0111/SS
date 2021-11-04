using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

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

                            if (xO > width-1 || yO > height-1 || xO < 0 || yO < 0)
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
                float w2 = (w/2) / (scaleFactor), h2 = (h /2) /(scaleFactor);

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

                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                            dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                            dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                            dataPtrCopy += nChan;
                            dataPtr += nChan;
                        }
                        dataPtrCopy += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }
                    //processar pixel (0,0)
                    dataPtr = resetPtr; // reset ao pointer 
                    blueSum = 4*dataPtrBorder[0] + 2*(dataPtrBorder + nChan)[0] + 2*(dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0];
                    greenSum = 4*dataPtrBorder[1] + 2*(dataPtrBorder + nChan)[1] + 2*(dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1];
                    redSum = 4*dataPtrBorder[2] + 2*(dataPtrBorder + nChan)[2] + 2*(dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2];
                    dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    dataPtr[2] = (byte)Math.Round(redSum / 9.0);

                    //processar a border superior a partir do segundo pixel
                    dataPtr += nChan;
                    dataPtrBorder += nChan;
                    for (x = 1; x < width - 1 ; x++)
                    {
                        blueSum = 2*dataPtrBorder[0] + 2*(dataPtrBorder - nChan)[0] + 2*(dataPtrBorder + nChan)[0] + (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0];
                        greenSum = 2*dataPtrBorder[1] + 2*(dataPtrBorder - nChan)[1] + 2*(dataPtrBorder + nChan)[1] + (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1];
                        redSum = 2*dataPtrBorder[2] + 2*(dataPtrBorder - nChan)[2] + 2*(dataPtrBorder + nChan)[2] + (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2];
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        dataPtr += nChan;
                        dataPtrBorder += nChan;
                    }

 
                    //processar pixel (0,N)
                    blueSum = 4*dataPtrBorder[0] + 2*(dataPtrBorder - nChan)[0] + 2*(dataPtrBorder - widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                    greenSum = 4*dataPtrBorder[1] + 2*(dataPtrBorder - nChan)[1] + 2*(dataPtrBorder - widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                    redSum = 4*dataPtrBorder[2] + 2*(dataPtrBorder - nChan)[2] + 2*(dataPtrBorder - widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];
                    dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    dataPtrBorder += nChan + padding + nChan;
                    dataPtr += nChan + padding + nChan;

                    //processar border direita
                    for (y = 1; y < height - 1; y++)
                    {
                        blueSum = 2*dataPtrBorder[0] + 2*(dataPtrBorder - widthStep)[0] + 2*(dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan)[0] + (dataPtrBorder - nChan + widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan)[1] + (dataPtrBorder - nChan + widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan)[2] + (dataPtrBorder - nChan + widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        dataPtrBorder += nChan + padding + nChan;
                        dataPtr += nChan + padding + nChan;
                    }

                    //processar pixel (N,N)
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan + widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan + widthStep)[2];
                    dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    dataPtr -= nChan;
                    dataPtrBorder -= nChan;

                    //processar border inferior
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - nChan)[0] + 2 * (dataPtrBorder + nChan)[0] + (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - nChan)[1] + 2 * (dataPtrBorder + nChan)[1] + (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - nChan)[2] + 2 * (dataPtrBorder + nChan)[2] + (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        dataPtr -= nChan;
                        dataPtrBorder -= nChan;
                    }

                    //processar pixel (N,0)
                    blueSum = 4 * dataPtrBorder[0] + 2 * (dataPtrBorder + nChan)[0] + 2 * (dataPtrBorder - widthStep)[0] + (dataPtrBorder + nChan - widthStep)[0];
                    greenSum = 4 * dataPtrBorder[1] + 2 * (dataPtrBorder + nChan)[1] + 2 * (dataPtrBorder - widthStep)[1] + (dataPtrBorder + nChan - widthStep)[1];
                    redSum = 4 * dataPtrBorder[2] + 2 * (dataPtrBorder + nChan)[2] + 2 * (dataPtrBorder - widthStep)[2] + (dataPtrBorder + nChan - widthStep)[2];
                    dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                    dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                    dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                    dataPtrBorder += nChan + padding + nChan;
                    dataPtr += nChan + padding + nChan;

                    //processar border esquerda
                    for (x = 1; x < width - 1; x++)
                    {
                        blueSum = 2 * dataPtrBorder[0] + 2 * (dataPtrBorder - widthStep)[0] + 2 * (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder + nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder + nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder + nChan - widthStep)[2];
                        dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        dataPtr[1] = (byte)Math.Round(greenSum / 9.0);
                        dataPtr[2] = (byte)Math.Round(redSum / 9.0);
                        dataPtrBorder -= nChan + padding + nChan;
                        dataPtr -= nChan + padding + nChan;
                    }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgCopy"></param>
        public static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            //  imgCopy.SmoothMedian(3).CopyTo(img);

            unsafe
            {
                // acesso directo à memoria da imagem (sequencial)
                // top left to bottom right
                MIplImage m = img.MIplImage;
                img.SetZero();

                MIplImage mU = imgCopy.MIplImage;

                byte* dataPtr = (Byte*)m.imageData.ToPointer();
                byte* dataPtrIn = (Byte*)mU.imageData.ToPointer();
                int h = img.Height;
                int w = img.Width;
                int nC = m.nChannels;
                int mWs = m.widthStep;
                int lineStep = m.widthStep - m.nChannels * m.width + 2 * m.nChannels;
                int x, y, i;
                int outvalue;

                byte[] valuesB = new byte[9], valuesG = new byte[9], valuesR = new byte[9];
                int distMin = int.MaxValue, distAux;
                int idxMin = 0;

                dataPtr += m.nChannels + m.widthStep;
                dataPtrIn += m.nChannels + m.widthStep;
                int ii, j;
                // no borders
                for (y = 1; y < h - 1; y++)
                {
                    for (x = 1; x < w - 1; x++)
                    {
                        i = 0;
                        valuesB[0] = (dataPtrIn - mWs - nC)[i];
                        valuesB[1] = (dataPtrIn - mWs)[i];
                        valuesB[2] = (dataPtrIn - mWs + nC)[i];
                        valuesB[3] = (dataPtrIn - nC)[i];
                        valuesB[4] = (dataPtrIn)[i];
                        valuesB[5] = (dataPtrIn + nC)[i];
                        valuesB[6] = (dataPtrIn + mWs - nC)[i];
                        valuesB[7] = (dataPtrIn + mWs)[i];
                        valuesB[8] = (dataPtrIn + mWs + nC)[i];

                        i = 1;
                        valuesG[0] = (dataPtrIn - mWs - nC)[i];
                        valuesG[1] = (dataPtrIn - mWs)[i];
                        valuesG[2] = (dataPtrIn - mWs + nC)[i];
                        valuesG[3] = (dataPtrIn - nC)[i];
                        valuesG[4] = (dataPtrIn)[i];
                        valuesG[5] = (dataPtrIn + nC)[i];
                        valuesG[6] = (dataPtrIn + mWs - nC)[i];
                        valuesG[7] = (dataPtrIn + mWs)[i];
                        valuesG[8] = (dataPtrIn + mWs + nC)[i];
                        i = 2;
                        valuesR[0] = (dataPtrIn - mWs - nC)[i];
                        valuesR[1] = (dataPtrIn - mWs)[i];
                        valuesR[2] = (dataPtrIn - mWs + nC)[i];
                        valuesR[3] = (dataPtrIn - nC)[i];
                        valuesR[4] = (dataPtrIn)[i];
                        valuesR[5] = (dataPtrIn + nC)[i];
                        valuesR[6] = (dataPtrIn + mWs - nC)[i];
                        valuesR[7] = (dataPtrIn + mWs)[i];
                        valuesR[8] = (dataPtrIn + mWs + nC)[i];

                        // calculate distance
                        distMin = int.MaxValue;
                        for (ii = 0; ii < 9; ii++)
                        {
                            distAux = 0;
                            for (j = 0; j < 9; j++)
                            {
                                distAux +=
                                    Math.Abs(valuesB[ii] - valuesB[j]) +
                                    Math.Abs(valuesG[ii] - valuesG[j]) +
                                    Math.Abs(valuesR[ii] - valuesR[j]);

                            }
                            idxMin = (distMin > distAux) ? ii : idxMin;
                            distMin = (distMin > distAux) ? distAux : distMin;

                        }

                        dataPtr[0] = (byte)valuesB[idxMin];
                        dataPtr[1] = (byte)valuesG[idxMin];
                        dataPtr[2] = (byte)valuesR[idxMin];





                        // avança apontador 
                        dataPtr += nC;
                        dataPtrIn += nC;

                    }

                    //no fim da linha avança alinhamento
                    dataPtr += lineStep;
                    dataPtrIn += lineStep;
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
        public static Image<Bgr, byte> BarCodeReader(Image<Bgr, byte> img, int type, 
    out Point bc_centroid1, out Size bc_size1,out string bc_image1, out string bc_number1, 
    out Point bc_centroid2, out Size bc_size2, out string bc_image2, out string bc_number2)
{
    // first barcode
    bc_image1 = "5601212323434";
    bc_number1 = "9780201379624";
    bc_centroid1 = new Point(130,60);
    bc_size1 = new Size(200,80);

            //second barcode
            /*bc_image2 = null;
            bc_number2 = null;
            bc_centroid2 = Point.Empty;
            bc_size2 = Size.Empty;
            */
            bc_image2 = "5601212323434";
            bc_number2 = "5601212323434";
            bc_centroid2 = new Point(100, 50);
            bc_size2 = new Size(30, 10);

            // draw the rectangle over the destination image 
            img.Draw(new Rectangle(bc_centroid1.X - bc_size1.Width / 2,
                                    bc_centroid1.Y - bc_size1.Height / 2,
                                    bc_size1.Width,
                                    bc_size1.Height), 
                new Bgr(0, 255, 0), 3);

    return img;
}
    }
}
