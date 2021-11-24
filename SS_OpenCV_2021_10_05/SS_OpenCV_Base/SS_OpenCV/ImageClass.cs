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
                    blueSum = 4*dataPtrBorder[0] + 2*(dataPtrBorder + nChan)[0] + 2*(dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0];
                    greenSum = 4*dataPtrBorder[1] + 2*(dataPtrBorder + nChan)[1] + 2*(dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1];
                    redSum = 4*dataPtrBorder[2] + 2*(dataPtrBorder + nChan)[2] + 2*(dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2];

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
                    for (x = 1; x < width - 1 ; x++)
                    {
                        blueSum = 2*dataPtrBorder[0] + 2*(dataPtrBorder - nChan)[0] + 2*(dataPtrBorder + nChan)[0] + (dataPtrBorder + widthStep)[0] + (dataPtrBorder + nChan + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                        greenSum = 2*dataPtrBorder[1] + 2*(dataPtrBorder - nChan)[1] + 2*(dataPtrBorder + nChan)[1] + (dataPtrBorder + widthStep)[1] + (dataPtrBorder + nChan + widthStep)[1] + (dataPtrBorder - nChan + widthStep)[1];
                        redSum = 2*dataPtrBorder[2] + 2*(dataPtrBorder - nChan)[2] + 2*(dataPtrBorder + nChan)[2] + (dataPtrBorder + widthStep)[2] + (dataPtrBorder + nChan + widthStep)[2] + (dataPtrBorder - nChan + widthStep)[2];
                        
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
                    blueSum = 4*dataPtrBorder[0] + 2*(dataPtrBorder - nChan)[0] + 2*(dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan + widthStep)[0];
                    greenSum = 4*dataPtrBorder[1] + 2*(dataPtrBorder - nChan)[1] + 2*(dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan + widthStep)[1];
                    redSum = 4*dataPtrBorder[2] + 2*(dataPtrBorder - nChan)[2] + 2*(dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan + widthStep)[2];

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
                    dataPtrBorder += widthStep ;
                    dataPtr += widthStep ;

                    //processar border direita
                    for (y = 1; y < height - 1; y++)
                    {
                        blueSum = 2*dataPtrBorder[0] + 2*(dataPtrBorder - widthStep)[0] + 2*(dataPtrBorder + widthStep)[0] + (dataPtrBorder - nChan)[0] + (dataPtrBorder - nChan + widthStep)[0] + (dataPtrBorder - nChan - widthStep)[0];
                        greenSum = 2 * dataPtrBorder[1] + 2 * (dataPtrBorder - widthStep)[1] + 2 * (dataPtrBorder + widthStep)[1] + (dataPtrBorder - nChan)[1] + (dataPtrBorder - nChan + widthStep)[1] + (dataPtrBorder - nChan - widthStep)[1];
                        redSum = 2 * dataPtrBorder[2] + 2 * (dataPtrBorder - widthStep)[2] + 2 * (dataPtrBorder + widthStep)[2] + (dataPtrBorder - nChan)[2] + (dataPtrBorder - nChan + widthStep)[2] + (dataPtrBorder - nChan - widthStep)[2];

                        if (Math.Round(blueSum / 9.0) > 255)
                            dataPtr[0] = 255;
                        else
                            dataPtr[0] = (byte)Math.Round(blueSum / 9.0);
                        if (Math.Round(greenSum / 9.0) > 255)
                            dataPtr[1] = 255;
                        else
                            dataPtr[1] =  (byte)Math.Round(greenSum / 9.0);
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
                        dataPtrBorder += widthStep ;
                        dataPtr += widthStep ;
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
                        dataPtr[2] =  (byte)Math.Round(redSum / 9.0);

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
                            dataPtr[0] =  (byte)Math.Round(blueSum / 9.0);
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
                        dataPtr[1] =  (byte)Math.Round(greenSum / 9.0);
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
                        dataPtrBorder -= widthStep  ;
                        dataPtr -= widthStep ;
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

                            SBlue = Math.Abs(SxBlueSum)+ Math.Abs(SyBlueSum);
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
                        dataPtrCopy +=  padding + nChan;
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
                int[, ] hist = new int[3,256];

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

                    imgVecB[0] = (dataPtrCopy )[0];
                    imgVecG[0] = (dataPtrCopy )[1];
                    imgVecR[0] = (dataPtrCopy )[2];

                    imgVecB[1] = (dataPtrCopy )[0];
                    imgVecG[1] = (dataPtrCopy )[1];
                    imgVecR[1] = (dataPtrCopy )[2];

                    imgVecB[2] = (dataPtrCopy  + nChan)[0];
                    imgVecG[2] = (dataPtrCopy  + nChan)[1];
                    imgVecR[2] = (dataPtrCopy  + nChan)[2];

                    imgVecB[3] = (dataPtrCopy )[0];
                    imgVecG[3] = (dataPtrCopy )[1];
                    imgVecR[3] = (dataPtrCopy )[2];

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
                    dataPtr[0] =  imgVecB[index];
                    dataPtr[1] =  imgVecG[index];
                    dataPtr[2] =  imgVecR[index];

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

                    imgVecB[2] = (dataPtrCopy )[0];
                    imgVecG[2] = (dataPtrCopy )[1];
                    imgVecR[2] = (dataPtrCopy )[2];

                    imgVecB[3] = (dataPtrCopy - nChan)[0];
                    imgVecG[3] = (dataPtrCopy - nChan)[1];
                    imgVecR[3] = (dataPtrCopy - nChan)[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy )[0];
                    imgVecG[5] = (dataPtrCopy )[1];
                    imgVecR[5] = (dataPtrCopy )[2];

                    imgVecB[6] = (dataPtrCopy + widthStep - nChan)[0];
                    imgVecG[6] = (dataPtrCopy + widthStep - nChan)[1];
                    imgVecR[6] = (dataPtrCopy + widthStep - nChan)[2];

                    imgVecB[7] = (dataPtrCopy + widthStep)[0];
                    imgVecG[7] = (dataPtrCopy + widthStep)[1];
                    imgVecR[7] = (dataPtrCopy + widthStep)[2];

                    imgVecB[8] = (dataPtrCopy + widthStep )[0];
                    imgVecG[8] = (dataPtrCopy + widthStep )[1];
                    imgVecR[8] = (dataPtrCopy + widthStep )[2];

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

                    imgVecB[5] = (dataPtrCopy )[0];
                    imgVecG[5] = (dataPtrCopy )[1];
                    imgVecR[5] = (dataPtrCopy )[2];

                    imgVecB[6] = (dataPtrCopy - nChan)[0];
                    imgVecG[6] = (dataPtrCopy - nChan)[1];
                    imgVecR[6] = (dataPtrCopy - nChan)[2];

                    imgVecB[7] = (dataPtrCopy )[0];
                    imgVecG[7] = (dataPtrCopy )[1];
                    imgVecR[7] = (dataPtrCopy )[2];

                    imgVecB[8] = (dataPtrCopy )[0];
                    imgVecG[8] = (dataPtrCopy )[1];
                    imgVecR[8] = (dataPtrCopy )[2];

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

                    imgVecB[0] = (dataPtrCopy  - widthStep)[0];
                    imgVecG[0] = (dataPtrCopy  - widthStep)[1];
                    imgVecR[0] = (dataPtrCopy  - widthStep)[2];

                    imgVecB[1] = (dataPtrCopy - widthStep)[0];
                    imgVecG[1] = (dataPtrCopy - widthStep)[1];
                    imgVecR[1] = (dataPtrCopy - widthStep)[2];

                    imgVecB[2] = (dataPtrCopy - widthStep + nChan)[0];
                    imgVecG[2] = (dataPtrCopy - widthStep + nChan)[1];
                    imgVecR[2] = (dataPtrCopy - widthStep + nChan)[2];

                    imgVecB[3] = (dataPtrCopy )[0];
                    imgVecG[3] = (dataPtrCopy )[1];
                    imgVecR[3] = (dataPtrCopy )[2];

                    imgVecB[4] = (dataPtrCopy)[0];
                    imgVecG[4] = (dataPtrCopy)[1];
                    imgVecR[4] = (dataPtrCopy)[2];

                    imgVecB[5] = (dataPtrCopy + nChan)[0];
                    imgVecG[5] = (dataPtrCopy + nChan)[1];
                    imgVecR[5] = (dataPtrCopy + nChan)[2];

                    imgVecB[6] = (dataPtrCopy )[0];
                    imgVecG[6] = (dataPtrCopy )[1];
                    imgVecR[6] = (dataPtrCopy )[2];

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
                        for (x = 0; x < width ; x++)
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
                        dataPtr +=  padding;
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
                int nC = m.nChannels;
                byte blue, green, red, gray;
                int q1 = 1;
                int q2 = 1;
                int variancia, u1, u2, t, i;
                int ip1 = 0; 
                int ip2 = 0;
                int numPix;
                int sum = 0;
                int  varMin = int.MaxValue;
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

                    for(t = 1; t < 255; t++)
                    {
                        for (i = 1; i <= t; i++) 
                        {
                            q1 += hist[i]/numPix;
                            ip1 += i * (hist[i] / numPix);
                        }
                            
                        for (i = t+1; i < 256; i++)
                        {
                            q2 += hist[i]/numPix;
                            ip2 += i * (hist[i] / numPix);
                        }

                        u1 = ip1 / q1;
                        u2 = ip2 / q2;

                        variancia = q1 * q2 * (int)Math.Pow((u1 - u2), 2);

                        if (variancia < varMin)
                        {
                            threshold = t;
                            varMin = variancia;
                        }
                            
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
