//using System;
//using System.Threading.Tasks;
//using Windows.Devices.Enumeration;
//using Windows.Devices.Nfc;
//using Windows.Storage.Streams;
//using VehiclePhotography.App.DAO.Interfaces;

//namespace VehiclePhotography.App.DAO.Services
//{
//    public class AcrNfcReaderDao : INfcReaderDao
//    {
//        private NfcReaderDevice _reader;
//        private DataReader _dataReader;

//        public async Task Initialize()
//        {
//            // Find the first NFC reader device
//            string selector = NfcReaderDevice.GetDeviceSelector();
//            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);

//            if (devices.Count > 0)
//            {
//                // Initialize the NFC reader
//                _reader = await NfcReaderDevice.FromIdAsync(devices[0].Id);

//                if (_reader != null)
//                {
//                    // Subscribe to the NfcMessageReceived event
//                    _reader.NfcMessageReceived += Reader_NfcMessageReceived;
//                    _dataReader = new DataReader(_reader.InputStream);

//                    // Start listening for NFC messages
//                    await _reader.SubscribeToMessagesAsync();
//                    Console.WriteLine("NFC reader initialized. Waiting for NFC messages...");
//                }
//                else
//                {
//                    Console.WriteLine("Failed to initialize NFC reader.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No NFC reader devices found.");
//            }
//        }

//        private async void Reader_NfcMessageReceived(NfcReaderDevice sender, NfcMessageReceivedEventArgs args)
//        {
//            try
//            {
//                // Read the NFC message
//                NfcMessage message = await args.GetNfcMessageAsync();

//                if (message != null && message.Data.Count > 0)
//                {
//                    // Extract the data from the message
//                    IBuffer buffer = message.Data[0];

//                    // Convert the buffer to a string
//                    string data = DataReader.FromBuffer(buffer).ReadString(buffer.Length);

//                    // Process the NFC data
//                    Console.WriteLine("NFC data received: " + data);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error reading NFC message: " + ex.Message);
//            }
//        }

//        public async Task Cleanup()
//        {
//            // Unsubscribe from NFC messages and clean up resources
//            if (_reader != null)
//            {
//                await _reader.UnsubscribeFromMessagesAsync();
//                _reader.NfcMessageReceived -= Reader_NfcMessageReceived;
//                _reader.Dispose();
//                _reader = null;
//            }
//            _dataReader?.Dispose();
//        }
//    }
//}
