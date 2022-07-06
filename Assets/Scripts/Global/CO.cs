namespace Const
{
    public static class CO
    {
        //---------------------------------------------
        //// *** 環境設定 *** ////
        //---------------------------------------------
        // 固定フレームレート
        public const int TARGET_FRAME_RATE = 60;

        // 解像度設定(横幅)
        public const int RESOLUTION_WIDTH = 1080;

        // 解像度設定(縦幅)
        public const int RESOLUTION_HEIGHT = 1920;

        // ゲームバージョン
        public const string STRING_GAME_VERSION = "0.0.1";

        // セーブデータファイル名
        public const string SAVE_FILE_NAME = "savedata.json";
        //---------------------------------------------
        //// *** ゲーム設定 *** ////
        //---------------------------------------------
        // 時間制限
        public const int TIME_LIMIT = 5;

        // タッチされてオブジェクトが移動し始めてから移動がおわるまでの時間(フレーム)
        // この間はタッチされてもUpdatePositionを行わない
        public const int MOVING_TIME = 7;

        //増加させるスコア量
        public const int ADD_SCORE = 10;

        // コンボを継続させるための猶予フレーム
        public const int COMBO_EXTENSION_FRAME = 30;

        // HSVのHの最大値
        public const int MAXHSVCOLOR = 360;

        // 時間制限
        public const float RAYCAST_MAX_DISTANCE = 20.0f;

        // コンボ倍率
        public const float COMBO_MAGNIFICATION = 0.1f;

        // RETRY(文字列)
        public const string STRING_RETRY = "RETRY";

        // GIVE UP(文字列)
        public const string STRING_GIVE_UP = "GIVE UP";
    }
    // テスト、デバッグ用定数(リリース対応時にすべて削除)
    public static class TEST
    {
        // 取得コイン数
        public const int GETCOINS = 100;
    }
}