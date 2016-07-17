public void Test()
        {
            string inputValue = string.Empty;
            int loopCount = 0;

            //  사용자 입력
            do
            {
                inputValue = Console.ReadLine();
            }
            while ((int.TryParse(inputValue, out loopCount) == false) || loopCount < 0 || loopCount > 10000);

            // Byte 연산 및 출력
            byte[] input;
            byte[] output;

            for (int i = 1; i <= loopCount; i++)
            {
                try
                {
                    input = BitConverter.GetBytes(uint.Parse(Console.ReadLine()));
                }
                catch
                {
                    i--;
                    continue;
                }

                output = new byte[input.Length];
                for (int j = 1; j <= input.Length; j++)
                {
                    output[j-1] = input[input.Length - j];
                }

                Console.WriteLine(BitConverter.ToUInt32(output, 0).ToString());                
            }
        }